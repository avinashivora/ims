using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ims.Services;
using ims.UI.Forms;

namespace ims.UI.Pages
{
    public partial class CategoriesPage : UserControl
    {
        private readonly CategoryService _categoryService;

        public CategoriesPage()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
            this.Load += async (_, _) => await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();

                if (categoriesDataGrid.Columns.Count == 0)
                {
                    categoriesDataGrid.Columns.Add("Id", "ID");
                    categoriesDataGrid.Columns.Add("Name", "Category Name");

                    var editBtn = new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    };
                    var deleteBtn = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };

                    categoriesDataGrid.Columns.Add(editBtn);
                    categoriesDataGrid.Columns.Add(deleteBtn);
                }

                categoriesDataGrid.Rows.Clear();

                foreach (var category in categories)
                {
                    categoriesDataGrid.Rows.Add(category.Id, category.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CategoriesDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columnName = categoriesDataGrid.Columns[e.ColumnIndex].Name;
            var categoryId = categoriesDataGrid.Rows[e.RowIndex].Cells["Id"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(categoryId)) return;

            if (columnName == "Edit")
            {
                using var form = new CategoryForm(categoryId);
                form.FormClosing += async (_, _) => await LoadCategoriesAsync();
                form.ShowDialog();
            }
            else if (columnName == "Delete")
            {
                try
                {
                    var items = await new ItemService().GetAllItemsAsync();
                    var itemsInCategory = items
                        .Where(i => i.CategoryId == categoryId)
                        .OrderBy(i => i.Name)
                        .ToList();

                    if (itemsInCategory.Count > 0)
                    {
                        var confirmForm = new CategoryItemViewer(itemsInCategory);
                        confirmForm.ShowDialog();

                        if (!confirmForm.ProceedWithDeletion) return;
                    }

                    var confirmDelete = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirmDelete == DialogResult.Yes)
                    {
                        await _categoryService.DeleteCategoryAsync(categoryId);
                        await LoadCategoriesAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete category:\n{ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            using var form = new CategoryForm();
            form.FormClosing += async (_, _) => await LoadCategoriesAsync();
            form.ShowDialog();
        }
    }
}
