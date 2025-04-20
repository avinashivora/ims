using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ims.UI.Pages;
using ims.Utils;

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

        private void InitializeComponent()
        {
            this.sidebarPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCreateCategory = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreateItem = new Guna.UI2.WinForms.Guna2Button();
            this.btnInventory = new Guna.UI2.WinForms.Guna2Button();
            this.btnBilling = new Guna.UI2.WinForms.Guna2Button();
            this.btnSetBillSavePath = new Guna.UI2.WinForms.Guna2Button();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.Controls.Add(this.btnCreateCategory);
            this.sidebarPanel.Controls.Add(this.btnCreateItem);
            this.sidebarPanel.Controls.Add(this.btnInventory);
            this.sidebarPanel.Controls.Add(this.btnBilling);
            this.sidebarPanel.Controls.Add(this.btnSetBillSavePath);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(244, 244);
            this.sidebarPanel.TabIndex = 0;
            // 
            // btnCreateCategory
            // 
            this.btnCreateCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCreateCategory.ForeColor = System.Drawing.Color.White;
            this.btnCreateCategory.Location = new System.Drawing.Point(0, 135);
            this.btnCreateCategory.Name = "btnCreateCategory";
            this.btnCreateCategory.Size = new System.Drawing.Size(244, 45);
            this.btnCreateCategory.TabIndex = 0;
            this.btnCreateCategory.Text = "Create Category";
            this.btnCreateCategory.Click += new System.EventHandler(this.BtnCreateCategory_Click);
            // 
            // btnCreateItem
            // 
            this.btnCreateItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCreateItem.ForeColor = System.Drawing.Color.White;
            this.btnCreateItem.Location = new System.Drawing.Point(0, 90);
            this.btnCreateItem.Name = "btnCreateItem";
            this.btnCreateItem.Size = new System.Drawing.Size(244, 45);
            this.btnCreateItem.TabIndex = 1;
            this.btnCreateItem.Text = "Create Item";
            this.btnCreateItem.Click += new System.EventHandler(this.BtnCreateItem_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInventory.ForeColor = System.Drawing.Color.White;
            this.btnInventory.Location = new System.Drawing.Point(0, 45);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(244, 45);
            this.btnInventory.TabIndex = 2;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.Click += new System.EventHandler(this.BtnInventory_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBilling.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBilling.ForeColor = System.Drawing.Color.White;
            this.btnBilling.Location = new System.Drawing.Point(0, 0);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(244, 45);
            this.btnBilling.TabIndex = 3;
            this.btnBilling.Text = "Billing";
            this.btnBilling.Click += new System.EventHandler(this.BtnBilling_Click);
            // 
            // btnSetBillSavePath
            // 
            this.btnSetBillSavePath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSetBillSavePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSetBillSavePath.ForeColor = System.Drawing.Color.White;
            this.btnSetBillSavePath.Location = new System.Drawing.Point(0, 199);
            this.btnSetBillSavePath.Name = "btnSetBillSavePath";
            this.btnSetBillSavePath.Size = new System.Drawing.Size(244, 45);
            this.btnSetBillSavePath.TabIndex = 4;
            this.btnSetBillSavePath.Text = "Set Bill Save Path";
            this.btnSetBillSavePath.Click += new System.EventHandler(this.BtnSetBillSavePath_Click);
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = System.Drawing.Color.White;
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(244, 0);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(34, 244);
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.sidebarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}