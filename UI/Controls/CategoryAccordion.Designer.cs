using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.UI.Controls
{
    partial class CategoryAccordion
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel headerPanel;
        private Guna2HtmlLabel lblCategory;
        private Guna2HtmlLabel lblCount;
        private Guna2Button btnToggle;
        private Guna2Button btnEdit;
        private Guna2Button btnDelete;
        private FlowLayoutPanel panelItems;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerPanel = new Guna2Panel();
            this.lblCategory = new Guna2HtmlLabel();
            this.lblCount = new Guna2HtmlLabel();
            this.btnEdit = new Guna2Button();
            this.btnDelete = new Guna2Button();
            this.btnToggle = new Guna2Button();
            this.panelItems = new FlowLayoutPanel();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = Color.Gainsboro;
            this.headerPanel.Controls.Add(this.lblCategory);
            this.headerPanel.Controls.Add(this.lblCount);
            this.headerPanel.Controls.Add(this.btnEdit);
            this.headerPanel.Controls.Add(this.btnDelete);
            this.headerPanel.Controls.Add(this.btnToggle);
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Location = new Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new Padding(10);
            this.headerPanel.Size = new Size(700, 50);
            this.headerPanel.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.BackColor = Color.Transparent;
            this.lblCategory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCategory.Location = new Point(45, 10);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new Size(210, 30);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category: Placeholder";
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.lblCount.BackColor = Color.Transparent;
            this.lblCount.Font = new Font("Segoe UI", 9F);
            this.lblCount.Location = new Point(620, 20);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new Size(70, 30);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "0 item(s)";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnEdit.FillColor = Color.SteelBlue;
            this.btnEdit.Font = new Font("Segoe UI", 9F);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Location = new Point(510, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(30, 30);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "✎";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnDelete.FillColor = Color.Firebrick;
            this.btnDelete.Font = new Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(545, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(30, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "🗑";
            // 
            // btnToggle
            // 
            this.btnToggle.FillColor = Color.DimGray;
            this.btnToggle.Font = new Font("Segoe UI", 9F);
            this.btnToggle.ForeColor = Color.White;
            this.btnToggle.Location = new Point(10, 10);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new Size(30, 30);
            this.btnToggle.TabIndex = 2;
            this.btnToggle.Text = "+";
            // 
            // panelItems
            // 
            this.panelItems.AutoSize = true;
            this.panelItems.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panelItems.Dock = DockStyle.Top;
            this.panelItems.FlowDirection = FlowDirection.TopDown;
            this.panelItems.Location = new Point(0, 50);
            this.panelItems.Name = "panelItems";
            this.panelItems.Padding = new Padding(10);
            this.panelItems.Size = new Size(700, 20);
            this.panelItems.TabIndex = 0;
            this.panelItems.Visible = false;
            this.panelItems.WrapContents = false;
            // 
            // CategoryAccordion
            // 
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.panelItems);
            this.Controls.Add(this.headerPanel);
            this.Name = "CategoryAccordion";
            this.Size = new Size(700, 300);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
