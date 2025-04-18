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
            this.btnInventory = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreateItem = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreateCategory = new Guna.UI2.WinForms.Guna2Button();
            this.mainContentPanel = new System.Windows.Forms.Panel();

            // 
            // sidebarPanel
            // 
            this.sidebarPanel.Dock = DockStyle.Left;
            this.sidebarPanel.Width = 200;
            this.sidebarPanel.FillColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.sidebarPanel.Controls.Add(this.btnCreateCategory);
            this.sidebarPanel.Controls.Add(this.btnCreateItem);
            this.sidebarPanel.Controls.Add(this.btnInventory);

            // 
            // btnInventory
            // 
            this.btnInventory.Text = "Inventory";
            this.btnInventory.Dock = DockStyle.Top;
            this.btnInventory.Click += new System.EventHandler(this.BtnInventory_Click);

            // 
            // btnCreateItem
            // 
            this.btnCreateItem.Text = "Create Item";
            this.btnCreateItem.Dock = DockStyle.Top;
            this.btnCreateItem.Click += new System.EventHandler(this.BtnCreateItem_Click);

            // 
            // btnCreateCategory
            // 
            this.btnCreateCategory.Text = "Create Category";
            this.btnCreateCategory.Dock = DockStyle.Top;
            this.btnCreateCategory.Click += new System.EventHandler(this.BtnCreateCategory_Click);

            // 
            // mainContentPanel
            // 
            this.mainContentPanel.Dock = DockStyle.Fill;
            this.mainContentPanel.BackColor = System.Drawing.Color.White;

            // 
            // MainForm
            // 
            this.Text = "Inventory Management System";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.sidebarPanel);
        }
    }
}
