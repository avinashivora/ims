using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ims.Models;
using ims.Services;

namespace ims.UI.Forms
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryService _categoryService;
        private readonly string _categoryId;
        public Category UpdatedCategory { get; private set; }
        public bool CategoryDeleted { get; private set; } = false;

        public CategoryForm(string categoryId = null)
        {
            InitializeComponent();
            _categoryService = new CategoryService();
            _categoryId = categoryId;
        }

        private async void CategoryForm_Load(object sender, EventArgs e)
        {
            txtCategoryName.Focus();

            if (!string.IsNullOrEmpty(_categoryId))
            {
                var category = await _categoryService.GetCategoryByIdAsync(_categoryId);
                if (category != null)
                {
                    txtCategoryName.Text = category.Name;
                }
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Category name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            var existingCategories = await _categoryService.GetAllCategoriesAsync();
            bool isDuplicate = existingCategories.Any(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase) && c.Id != _categoryId);

            if (isDuplicate)
            {
                MessageBox.Show("A category with the same name already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            try
            {
                if (!string.IsNullOrEmpty(_categoryId))
                {
                    var updatedCategory = new Category
                    {
                        Id = _categoryId,
                        Name = categoryName
                    };
                    await _categoryService.UpdateCategoryAsync(_categoryId, updatedCategory);
                    UpdatedCategory = updatedCategory; // Set the updated category
                    MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _categoryService.AddCategoryAsync(new Category { Name = categoryName });
                    MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_categoryId))
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this category?",
                                         "Confirm Delete",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Before deleting, check if the category has any items
                        var category = await _categoryService.GetCategoryByIdAsync(_categoryId);
                        if (category.ItemCount > 0)
                        {
                            MessageBox.Show("Cannot delete a category that contains items. Please remove the items first.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        await _categoryService.DeleteCategoryAsync(_categoryId);
                        CategoryDeleted = true;
                        MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Cannot delete a category that has not been saved yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}