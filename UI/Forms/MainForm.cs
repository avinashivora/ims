using System;
using System.Windows.Forms;
using ims.UI.Forms;
using ims.UI.Pages;

namespace ims
{
    public partial class MainForm : Form
    {
        private InventoryPage inventoryPage;

        public MainForm()
        {
            InitializeComponent();
            LoadInventoryPage();
        }

        private void LoadInventoryPage()
        {
            if (inventoryPage == null)
            {
                inventoryPage = new InventoryPage
                {
                    Dock = DockStyle.Fill
                };
                this.mainContentPanel.Controls.Add(inventoryPage);
            }

            inventoryPage.BringToFront();
        }

        private async void BtnCreateItem_Click(object sender, EventArgs e)
        {
            var itemForm = new ItemForm();
            itemForm.FormClosed += async (s, args) =>
            {
                // After closing, refresh the corresponding category
                if (itemForm.UpdatedItem != null)
                {
                    await inventoryPage.RefreshCategoryAccordion(itemForm.UpdatedItem.CategoryId);
                }
                else if (itemForm.NewItemCategoryId != null)
                {
                    await inventoryPage.HandleNewItemSaved(itemForm.NewItemCategoryId);
                }
            };
            itemForm.ShowDialog();
        }

        private async void BtnCreateCategory_Click(object sender, EventArgs e)
        {
            var categoryForm = new CategoryForm();
            categoryForm.FormClosed += async (s, args) =>
            {
                await inventoryPage.ReloadAllCategoriesAsync();
            };
            categoryForm.ShowDialog();
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            LoadInventoryPage();
        }
    }
}