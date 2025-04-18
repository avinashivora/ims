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
            this.txtCategoryName = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();

            this.SuspendLayout();

            // txtCategoryName
            this.txtCategoryName.BorderRadius = 6;
            this.txtCategoryName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCategoryName.DefaultText = "";
            this.txtCategoryName.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtCategoryName.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.txtCategoryName.FocusedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtCategoryName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCategoryName.HoverState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtCategoryName.Location = new System.Drawing.Point(30, 70);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.PlaceholderText = "Enter category name";
            this.txtCategoryName.Size = new System.Drawing.Size(300, 40);
            this.txtCategoryName.TabIndex = 0;

            // btnSave
            this.btnSave.BorderRadius = 6;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnSave.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(30, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(300, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Category";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // lblTitle
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(154, 27);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Category Details";

            // CategoryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 200);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCategoryName);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Category";
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
