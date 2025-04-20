using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ims.Models;
using ims.Services;
using ims.UI.Controls;
using ims.UI.Forms;
using ims.Utils;

namespace ims.UI.Pages
{
    public partial class InventoryPage : UserControl
    {
        private readonly ItemService _itemService;
        private readonly CategoryService _categoryService;
        private List<Category> _allCategories;
        private readonly Dictionary<string, List<Item>> _cachedItemsByCategoryId;
        private readonly Timer _searchDebounceTimer;
        private string _searchTextBuffer;

        public InventoryPage()
        {
            InitializeComponent();
            _itemService = new ItemService();
            _categoryService = new CategoryService();
            _cachedItemsByCategoryId = [];
            _searchDebounceTimer = new Timer { Interval = 400 };
            _searchDebounceTimer.Tick += SearchDebounceTimer_Tick;
        }

        private async void InventoryPage_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                _allCategories = await _categoryService.GetCategoriesWithItemCountsAsync();
                flowLayoutPanelCategories.Controls.Clear();

                foreach (var category in _allCategories.OrderBy(c => c.Name))
                {
                    var accordion = CreateCategoryAccordion(category);
                    flowLayoutPanelCategories.Controls.Add(accordion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CategoryAccordion CreateCategoryAccordion(Category category)
        {
            var accordion = new CategoryAccordion(category)
            {
                LoadItemsRequestedAsync = async (categoryId) =>
                {
                    if (_cachedItemsByCategoryId.TryGetValue(categoryId, out var cached))
                        return cached;

                    var items = await _itemService.GetItemsByCategoryIdAsync(categoryId);
                    _cachedItemsByCategoryId[categoryId] = items;
                    return items;
                }
            };

            accordion.ItemClicked += OnItemClicked;
            accordion.ItemDeleteRequested += OnItemDeleteRequestedAsync;
            accordion.ToggledOpen += OnCategoryToggledOpen;
            accordion.OnEditCategory += ShowCategoryEditForm;
            accordion.OnDeleteCategory += DeleteCategoryAsync;
            accordion.AddStockRequested += OnAddStockRequested;

            return accordion;
        }

        private void OnAddStockRequested(Item item)
        {
            var addStockForm = new AddStockForm(item);
            addStockForm.FormClosed += async (s, e) =>
            {
                if (addStockForm.UpdatedItem != null)
                {
                    // Remove the cached items to force a refresh
                    _cachedItemsByCategoryId.Remove(item.CategoryId);
                    await RefreshCategoryAccordion(item.CategoryId);
                }
            };
            addStockForm.ShowDialog();
        }

        private void OnItemClicked(Item item)
        {
            var itemForm = new ItemForm(item);
            itemForm.FormClosed += async (s, e) =>
            {
                var updatedItem = itemForm.UpdatedItem;
                if (updatedItem != null)
                {
                    if (updatedItem.CategoryId != item.CategoryId) // Category changed
                    {
                        // Update old category
                        if (_cachedItemsByCategoryId.TryGetValue(item.CategoryId, out var oldCategoryItems))
                        {
                            oldCategoryItems.RemoveAll(i => i.Id == updatedItem.Id);
                            await RefreshCategoryAccordion(item.CategoryId);
                            await UpdateCategoryItemCountDisplay(item.CategoryId);
                        }

                        // Update new category
                        _cachedItemsByCategoryId.Remove(updatedItem.CategoryId); // Force refresh
                        await RefreshCategoryAccordion(updatedItem.CategoryId);
                        await UpdateCategoryItemCountDisplay(updatedItem.CategoryId);
                    }
                    else // Same category, just updated
                    {
                        _cachedItemsByCategoryId.Remove(updatedItem.CategoryId);
                        await RefreshCategoryAccordion(updatedItem.CategoryId);
                        await UpdateCategoryItemCountDisplay(updatedItem.CategoryId);
                    }
                }
            };
            itemForm.ShowDialog();
        }

        private async void OnItemDeleteRequestedAsync(Item item)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                bool deletionSuccessful = false;
                try
                {
                    if (item.Quantity > 0 && CacheManager.CurrentUserRole != UserRole.Staff)
                    {
                        var quantConfirm = MessageBox.Show("This item is available in stock. Do you want to discard item from Inventory?", "Confirm Item Delete Available in Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (quantConfirm == DialogResult.Yes)
                        {
                            try
                            {
                                await _itemService.DeleteItemAsync(item.Id);
                                deletionSuccessful = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error deleting item: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Item deletion cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else if (item.Quantity > 0)
                    {
                        MessageBox.Show("This item is available in stock. You cannot delete it.\nTo remove Item from Inventory, Contact Admin!", "Item Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (item.Quantity == 0)
                    {
                        try
                        {
                            await _itemService.DeleteItemAsync(item.Id);
                            deletionSuccessful = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting item: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (deletionSuccessful)
                    {
                        _cachedItemsByCategoryId.Remove(item.CategoryId);
                        await RefreshCategoryAccordion(item.CategoryId);
                        await UpdateCategoryItemCountDisplay(item.CategoryId);

                        // Explicitly update the delete button state
                        var accordion = flowLayoutPanelCategories.Controls
                            .OfType<CategoryAccordion>()
                            .FirstOrDefault(c => c.Category.Id == item.CategoryId);
                        accordion?.UpdateDeleteButtonState();

                        MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting item: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task UpdateCategoryItemCountDisplay(string categoryId)
        {
            var accordion = flowLayoutPanelCategories.Controls
                .OfType<CategoryAccordion>()
                .FirstOrDefault(c => c.Category.Id == categoryId);
            if (accordion != null)
            {
                var items = await _itemService.GetItemsByCategoryIdAsync(categoryId);
                var itemCount = items.Count;
                var category = _allCategories?.FirstOrDefault(c => c.Id == categoryId);
                if (category != null)
                {
                    category.ItemCount = itemCount;
                }
                accordion.Category.ItemCount = itemCount;
                accordion.UpdateCategoryDisplay();
                accordion.UpdateDeleteButtonState(); // Update delete button state here
            }
        }

        public async Task RefreshCategoryAccordion(string categoryId)
        {
            var accordion = flowLayoutPanelCategories.Controls
                .OfType<CategoryAccordion>()
                .FirstOrDefault(c => c.Category.Id == categoryId);

            if (accordion != null)
            {
                var items = await _itemService.GetItemsByCategoryIdAsync(categoryId);
                _cachedItemsByCategoryId[categoryId] = items;
                accordion.LoadItems(items);
            }
        }

        private async void SearchDebounceTimer_Tick(object sender, EventArgs e)
        {
            _searchDebounceTimer.Stop();
            var search = _searchTextBuffer;
            flowLayoutPanelCategories.Controls.Clear();

            if (string.IsNullOrWhiteSpace(search))
            {
                await LoadCategoriesAsync();
                return;
            }

            foreach (var category in _allCategories)
            {
                var accordion = CreateCategoryAccordion(category);
                var items = await _itemService.GetItemsByCategoryIdAsync(category.Id);
                _cachedItemsByCategoryId[category.Id] = items;

                bool categoryMatch = category.Name.ToLower().Contains(search);
                var matchedItems = items.Where(i =>
                    i.Name.ToLower().Contains(search) ||
                    (i.Description ?? "").ToLower().Contains(search)).ToList();

                if (categoryMatch)
                {
                    accordion.LoadItems(items);
                    accordion.ToggleOpen(true);
                    flowLayoutPanelCategories.Controls.Add(accordion);
                }
                else if (matchedItems.Any())
                {
                    accordion.LoadItems(matchedItems);
                    accordion.ToggleOpen(true);
                    flowLayoutPanelCategories.Controls.Add(accordion);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchTextBuffer = txtSearch.Text.Trim().ToLower();
            _searchDebounceTimer.Stop();
            _searchDebounceTimer.Start();
        }

        private void OnCategoryToggledOpen(CategoryAccordion toggledAccordion)
        {
            foreach (var control in flowLayoutPanelCategories.Controls.OfType<CategoryAccordion>())
            {
                if (control != toggledAccordion && control.IsExpanded)
                {
                    control.ToggleOpen(false);
                }
            }
        }

        private void ShowCategoryEditForm(Category category)
        {
            var form = new CategoryForm(category.Id);
            form.FormClosed += async (s, e) =>
            {
                if (form.UpdatedCategory != null) // Check if an update occurred
                {
                    // Update the category in _allCategories
                    var existingCategory = _allCategories.FirstOrDefault(c => c.Id == category.Id);
                    if (existingCategory != null)
                    {
                        existingCategory.Name = form.UpdatedCategory.Name;
                    }

                    // Update the category name in the accordion
                    var accordion = flowLayoutPanelCategories.Controls
                        .OfType<CategoryAccordion>()
                        .FirstOrDefault(c => c.Category.Id == category.Id);
                    if (accordion != null)
                    {
                        accordion.Category.Name = form.UpdatedCategory.Name;
                        accordion.UpdateCategoryDisplay();
                    }
                }
                else if (form.CategoryDeleted)
                {
                    await ReloadAllCategoriesAsync();
                }
            };
            form.ShowDialog();
        }

        private async void DeleteCategoryAsync(string categoryId)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _categoryService.DeleteCategoryAsync(categoryId);
                    _cachedItemsByCategoryId.Remove(categoryId);
                    await LoadCategoriesAsync(); // Reload to update UI
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting category: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async Task ReloadAllCategoriesAsync()
        {
            _cachedItemsByCategoryId.Clear();
            await LoadCategoriesAsync();
        }

        public async Task HandleNewItemSaved(string categoryId)
        {
            await RefreshCategoryAccordion(categoryId);
            await UpdateCategoryItemCountDisplay(categoryId);

            // Explicitly update the delete button state
            var accordion = flowLayoutPanelCategories.Controls
                .OfType<CategoryAccordion>()
                .FirstOrDefault(c => c.Category.Id == categoryId);
            accordion?.UpdateDeleteButtonState();
        }
    }
}