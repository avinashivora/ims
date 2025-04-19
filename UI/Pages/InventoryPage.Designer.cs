using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.UI.Pages
{
    partial class InventoryPage
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2TextBox txtSearch;
        private FlowLayoutPanel flowLayoutPanelCategories;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSearch = new Guna2TextBox();
            this.flowLayoutPanelCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(20);
            this.txtSearch.PlaceholderText = "Search categories or items...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(960, 35);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // flowLayoutPanelCategories
            // 
            this.flowLayoutPanelCategories.AutoScroll = true;
            this.flowLayoutPanelCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelCategories.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelCategories.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelCategories.Name = "flowLayoutPanelCategories";
            this.flowLayoutPanelCategories.Padding = new System.Windows.Forms.Padding(100, 80, 20, 20);
            this.flowLayoutPanelCategories.Size = new System.Drawing.Size(960, 700);
            this.flowLayoutPanelCategories.TabIndex = 1;
            this.flowLayoutPanelCategories.WrapContents = false;
            // 
            // InventoryPage
            // 
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.flowLayoutPanelCategories);
            this.Name = "InventoryPage";
            this.Size = new System.Drawing.Size(960, 700);
            this.Load += new System.EventHandler(this.InventoryPage_Load);
            this.ResumeLayout(false);

        }
    }
}
