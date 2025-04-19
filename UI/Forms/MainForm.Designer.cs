using System.Windows.Forms;

namespace ims
{
    partial class MainForm
    {
        private Guna.UI2.WinForms.Guna2Panel sidebarPanel;
        private Guna.UI2.WinForms.Guna2Button btnInventory;
        private Guna.UI2.WinForms.Guna2Button btnCreateItem;
        private Guna.UI2.WinForms.Guna2Button btnCreateCategory;
        private Panel mainContentPanel;

        private void InitializeComponent()
        {
            this.sidebarPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCreateCategory = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreateItem = new Guna.UI2.WinForms.Guna2Button();
            this.btnInventory = new Guna.UI2.WinForms.Guna2Button();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.Controls.Add(this.btnCreateCategory);
            this.sidebarPanel.Controls.Add(this.btnCreateItem);
            this.sidebarPanel.Controls.Add(this.btnInventory);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(200, 244);
            this.sidebarPanel.TabIndex = 1;
            // 
            // btnCreateCategory
            // 
            this.btnCreateCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCreateCategory.ForeColor = System.Drawing.Color.White;
            this.btnCreateCategory.Location = new System.Drawing.Point(0, 90);
            this.btnCreateCategory.Name = "btnCreateCategory";
            this.btnCreateCategory.Size = new System.Drawing.Size(200, 45);
            this.btnCreateCategory.TabIndex = 0;
            this.btnCreateCategory.Text = "Create Category";
            this.btnCreateCategory.Click += new System.EventHandler(this.BtnCreateCategory_Click);
            // 
            // btnCreateItem
            // 
            this.btnCreateItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCreateItem.ForeColor = System.Drawing.Color.White;
            this.btnCreateItem.Location = new System.Drawing.Point(0, 45);
            this.btnCreateItem.Name = "btnCreateItem";
            this.btnCreateItem.Size = new System.Drawing.Size(200, 45);
            this.btnCreateItem.TabIndex = 1;
            this.btnCreateItem.Text = "Create Item";
            this.btnCreateItem.Click += new System.EventHandler(this.BtnCreateItem_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInventory.ForeColor = System.Drawing.Color.White;
            this.btnInventory.Location = new System.Drawing.Point(0, 0);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(200, 45);
            this.btnInventory.TabIndex = 2;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.Click += new System.EventHandler(this.BtnInventory_Click);
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = System.Drawing.Color.White;
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(200, 0);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(78, 244);
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
