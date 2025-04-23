using System;
using System.Windows.Forms;
using ims.Models;
using ims.UI.Controls;
using ims.UI.Pages;
using ims.Utils;

namespace ims.UI.Forms
{
    public partial class MainForm : Form
    {
        private InventoryPage inventoryPage;
        private BillingForm billingForm;
        private UserListControl userListControl;

        public MainForm()
        {
            InitializeComponent();
            SetupRoleBasedUI();
            LoadInventoryPage();
        }

        private void SetupRoleBasedUI()
        {
            // Get current user role from session
            var userRole = CacheManager.CurrentUserRole;

            // Show User Management button only for Admin and Manager roles
            btnUserManagement.Visible = (userRole == UserRole.Admin || userRole == UserRole.Manager);
            btnCreateCategory.Visible = (userRole != UserRole.Staff);
            btnCreateItem.Visible = (userRole != UserRole.Staff);
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

        private void BtnCreateItem_Click(object sender, EventArgs e)
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

        private void BtnCreateCategory_Click(object sender, EventArgs e)
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

        private void BtnBilling_Click(object sender, EventArgs e)
        {
            if (billingForm == null || billingForm.IsDisposed)
            {
                billingForm = new BillingForm();
                billingForm.FormClosed += async (s, args) =>
                {
                    // Refresh inventory after billing operations
                    if (inventoryPage != null && !inventoryPage.IsDisposed)
                    {
                        await inventoryPage.ReloadAllCategoriesAsync();
                    }
                };
            }
            billingForm.Show();
            billingForm.BringToFront();
        }

        private void BtnSetBillSavePath_Click(object sender, EventArgs e)
        {
            using var folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                CacheManager.BillSavePath = folderBrowser.SelectedPath;
                MessageBox.Show("Bill save path set to: " + CacheManager.BillSavePath);
            }
        }

        private void BtnUserManagement_Click(object sender, EventArgs e)
        {
            LoadUserManagementPage();
        }

        private void LoadUserManagementPage()
        {
            if (userListControl == null || userListControl.IsDisposed)
            {
                userListControl = new UserListControl
                {
                    Dock = DockStyle.Fill
                };
                this.mainContentPanel.Controls.Add(userListControl);
            }
            userListControl.BringToFront();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear session
                CacheManager.ClearSession();

                // Hide MainForm first to avoid flash
                this.Hide();
                // Close current MainForm instance
                this.Close();

                // Show login form again
                Program.ShowLoginForm();
            }
        }

    }
}