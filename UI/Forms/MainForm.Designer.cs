using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.UI.Forms
{
    partial class MainForm
    {
        private Guna2Panel sidebarPanel;
        private Guna2Button btnInventory;
        private Guna2Button btnCreateItem;
        private Guna2Button btnCreateCategory;
        private Guna2Button btnBilling;
        private Guna2Button btnSetBillSavePath;
        private Panel mainContentPanel;
        private Guna2Button btnUserManagement;
        private Guna2Button btnLogout;

        private void InitializeComponent()
        {
            this.sidebarPanel = new Guna2Panel();
            this.btnCreateCategory = new Guna2Button();
            this.btnCreateItem = new Guna2Button();
            this.btnInventory = new Guna2Button();
            this.btnBilling = new Guna2Button();
            this.btnUserManagement = new Guna2Button();
            this.btnSetBillSavePath = new Guna2Button();
            this.btnLogout = new Guna2Button();
            this.mainContentPanel = new Panel();
            this.sidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.Controls.Add(this.btnCreateCategory);
            this.sidebarPanel.Controls.Add(this.btnCreateItem);
            this.sidebarPanel.Controls.Add(this.btnInventory);
            this.sidebarPanel.Controls.Add(this.btnBilling);
            this.sidebarPanel.Controls.Add(this.btnUserManagement);
            this.sidebarPanel.Controls.Add(this.btnSetBillSavePath);
            this.sidebarPanel.Controls.Add(this.btnLogout);
            this.sidebarPanel.Dock = DockStyle.Left;
            this.sidebarPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(244, 244);
            this.sidebarPanel.TabIndex = 0;
            // 
            // btnCreateCategory
            // 
            this.btnCreateCategory.Dock = DockStyle.Top;
            this.btnCreateCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCreateCategory.ForeColor = System.Drawing.Color.White;
            this.btnCreateCategory.Location = new System.Drawing.Point(0, 180);
            this.btnCreateCategory.Name = "btnCreateCategory";
            this.btnCreateCategory.Size = new System.Drawing.Size(244, 45);
            this.btnCreateCategory.TabIndex = 0;
            this.btnCreateCategory.Text = "Create Category";
            this.btnCreateCategory.Click += new System.EventHandler(this.BtnCreateCategory_Click);
            // 
            // btnCreateItem
            // 
            this.btnCreateItem.Dock = DockStyle.Top;
            this.btnCreateItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCreateItem.ForeColor = System.Drawing.Color.White;
            this.btnCreateItem.Location = new System.Drawing.Point(0, 135);
            this.btnCreateItem.Name = "btnCreateItem";
            this.btnCreateItem.Size = new System.Drawing.Size(244, 45);
            this.btnCreateItem.TabIndex = 1;
            this.btnCreateItem.Text = "Create Item";
            this.btnCreateItem.Click += new System.EventHandler(this.BtnCreateItem_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Dock = DockStyle.Top;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInventory.ForeColor = System.Drawing.Color.White;
            this.btnInventory.Location = new System.Drawing.Point(0, 90);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(244, 45);
            this.btnInventory.TabIndex = 2;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.Click += new System.EventHandler(this.BtnInventory_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.Dock = DockStyle.Top;
            this.btnBilling.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBilling.ForeColor = System.Drawing.Color.White;
            this.btnBilling.Location = new System.Drawing.Point(0, 45);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(244, 45);
            this.btnBilling.TabIndex = 3;
            this.btnBilling.Text = "Billing";
            this.btnBilling.Click += new System.EventHandler(this.BtnBilling_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Dock = DockStyle.Top;
            this.btnUserManagement.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUserManagement.ForeColor = System.Drawing.Color.White;
            this.btnUserManagement.Location = new System.Drawing.Point(0, 0);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(244, 45);
            this.btnUserManagement.TabIndex = 5;
            this.btnUserManagement.Text = "User Management";
            this.btnUserManagement.Visible = false;
            this.btnUserManagement.Click += new System.EventHandler(this.BtnUserManagement_Click);
            // 
            // btnSetBillSavePath
            // 
            this.btnSetBillSavePath.Dock = DockStyle.Bottom;
            this.btnSetBillSavePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSetBillSavePath.ForeColor = System.Drawing.Color.White;
            this.btnSetBillSavePath.Location = new System.Drawing.Point(0, 154);
            this.btnSetBillSavePath.Name = "btnSetBillSavePath";
            this.btnSetBillSavePath.Size = new System.Drawing.Size(244, 45);
            this.btnSetBillSavePath.TabIndex = 4;
            this.btnSetBillSavePath.Text = "Set Bill Save Path";
            this.btnSetBillSavePath.Click += new System.EventHandler(this.BtnSetBillSavePath_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = DockStyle.Bottom;
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 199);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(244, 45);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = System.Drawing.Color.White;
            this.mainContentPanel.Dock = DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(244, 0);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(38, 244);
            this.mainContentPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Name = "MainForm";
            this.Text = "Stock-er";
            this.WindowState = FormWindowState.Maximized;
            this.sidebarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}