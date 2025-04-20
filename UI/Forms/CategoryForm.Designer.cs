using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.UI.Forms
{
    partial class CategoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2TextBox txtCategoryName;
        private Guna2Button btnSave;
        private Guna2HtmlLabel lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCategoryName = new Guna2TextBox();
            this.btnSave = new Guna2Button();
            this.lblTitle = new Guna2HtmlLabel();

            this.SuspendLayout();

            // txtCategoryName
            this.txtCategoryName.BorderRadius = 6;
            this.txtCategoryName.Cursor = Cursors.IBeam;
            this.txtCategoryName.DefaultText = "";
            this.txtCategoryName.DisabledState.BorderColor = Color.DarkGray;
            this.txtCategoryName.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            this.txtCategoryName.FocusedState.BorderColor = Color.DodgerBlue;
            this.txtCategoryName.Font = new Font("Segoe UI", 10F);
            this.txtCategoryName.HoverState.BorderColor = Color.DodgerBlue;
            this.txtCategoryName.Location = new Point(30, 70);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.PlaceholderText = "Enter category name";
            this.txtCategoryName.Size = new Size(300, 40);
            this.txtCategoryName.TabIndex = 0;

            // btnSave
            this.btnSave.BorderRadius = 6;
            this.btnSave.DisabledState.BorderColor = Color.DarkGray;
            this.btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            this.btnSave.FillColor = Color.DodgerBlue;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(30, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(300, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Category";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // lblTitle
            this.lblTitle.BackColor = Color.Transparent;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DodgerBlue;
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(154, 27);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Category Details";

            // CategoryForm
            this.AutoScaleDimensions = new SizeF(8F, 18F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(364, 200);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCategoryName);
            this.Font = new Font("Segoe UI", 9.75F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "CategoryForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Category";
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
