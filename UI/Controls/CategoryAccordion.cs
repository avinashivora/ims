using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ims.Models;

namespace ims.UI.Controls
{
    public partial class CategoryAccordion : UserControl
    {
        private Category _category; // Changed to non-readonly
        private List<Item> _cachedItems;
        private bool _isExpanded = false;
        private readonly ToolTip _toolTip;
        private const int VerticalPadding = 10; // Padding for the panelItems

        public event Action<CategoryAccordion> ToggledOpen;
        public event Action<Item> ItemClicked;
        public event Action<Item> ItemDeleteRequested;
        public event Action<Item> AddStockRequested;

        public Func<string, Task<List<Item>>> LoadItemsRequestedAsync;

        // Modified event to pass the Category object
        public event Action<Category> OnEditCategory;
        public event Action<string> OnDeleteCategory;

        public CategoryAccordion(Category category)
        {
            InitializeComponent();
            _category = category;
            UpdateCategoryDisplay();

            _toolTip = new ToolTip();

            btnToggle.Click += async (s, e) => await ToggleAsync();
            // Modified Edit button click to invoke the event with the Category object
            btnEdit.Click += (s, e) => OnEditCategory?.Invoke(_category);
            btnDelete.Click += (s, e) => OnDeleteCategory?.Invoke(_category.Id);

            UpdateDeleteButtonState();

            panelItems.Padding = new Padding(10, VerticalPadding, 10, VerticalPadding);
        }

        public void UpdateDeleteButtonState()
        {
            btnDelete.Enabled = _category.ItemCount == 0;
            _toolTip.SetToolTip(btnDelete,
                _category.ItemCount == 0
                    ? "Delete this category"
                    : "Cannot delete a category with items");
        }

        public string CategoryId => _category.Id;
        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
                UpdateCategoryDisplay();
                UpdateDeleteButtonState();
            }
        }
        public bool IsExpanded => _isExpanded;

        private async Task ToggleAsync()
        {
            if (_isExpanded)
            {
                Collapse();
            }
            else
            {
                if (_cachedItems == null && LoadItemsRequestedAsync != null)
                {
                    var items = await LoadItemsRequestedAsync.Invoke(_category.Id);
                    LoadItems(items); // Also expands
                }
                else
                {
                    Expand();
                }
            }
        }

        public void ToggleOpen(bool expand)
        {
            if (expand && !_isExpanded)
            {
                _ = ToggleAsync(); // fire and forget
            }
            else if (!expand && _isExpanded)
            {
                Collapse();
            }
        }

        public void LoadItems(List<Item> items)
        {
            _cachedItems = [.. items.OrderBy(i => i.Name)];
            // Console.WriteLine($"Loaded {_cachedItems.Count} items for category {_category.Name}");
            RenderAllItems();
            Expand();
        }

        private void RenderAllItems()
        {
            panelItems.Controls.Clear();
            int totalHeight = VerticalPadding; // Start with top padding

            foreach (var item in _cachedItems)
            {
                var card = new ItemPreviewCard(item)
                {
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 5)
                };
                card.ItemClicked += i => ItemClicked?.Invoke(i);
                card.ItemDeleteRequested += i => ItemDeleteRequested?.Invoke(i);
                card.AddStockRequested += i => AddStockRequested?.Invoke(i);
                panelItems.Controls.Add(card);
                totalHeight += card.Height + card.Margin.Bottom;
            }

            totalHeight += VerticalPadding; // Add bottom padding
            panelItems.Height = totalHeight;

            // Force layout update after adding controls
            panelItems.PerformLayout();
        }

        private void Expand()
        {
            panelItems.Visible = true;
            _isExpanded = true;
            btnToggle.Text = "−";
            ToggledOpen?.Invoke(this);
            AdjustHeight();
        }

        public void Collapse()
        {
            panelItems.Visible = false;
            _isExpanded = false;
            btnToggle.Text = "+";
            AdjustHeight();
        }

        private void AdjustHeight()
        {
            if (_isExpanded && _cachedItems != null)
            {
                int totalHeight = headerPanel.Height + VerticalPadding;
                foreach (Control control in panelItems.Controls)
                {
                    totalHeight += control.Height + control.Margin.Bottom;
                }
                totalHeight += VerticalPadding;
                this.Height = totalHeight;
            }
            else
            {
                this.Height = headerPanel.Height;
            }
        }

        public void UpdateCategoryDisplay()
        {
            lblCategory.Text = $"Category: {_category.Name}";
            lblCount.Text = $"{_category.ItemCount} item(s)";
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            AdjustHeight();
        }
    }
}