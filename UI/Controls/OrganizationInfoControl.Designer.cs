using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.UI.Controls
{
    partial class OrganizationInfoControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelOrg = new Guna2Panel();
            this.lblTitle = new Label();
            this.lblOrgName = new Label();
            this.lblCreatedAt = new Label();
            this.btnDelete = new Guna2Button();
            this.panelOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOrg
            // 
            this.panelOrg.BorderRadius = 10;
            this.panelOrg.Controls.Add(this.btnDelete);
            this.panelOrg.Controls.Add(this.lblCreatedAt);
            this.panelOrg.Controls.Add(this.lblOrgName);
            this.panelOrg.Controls.Add(this.lblTitle);
            this.panelOrg.Dock = DockStyle.Fill;
            this.panelOrg.FillColor = Color.White;
            this.panelOrg.Location = new Point(0, 0);
            this.panelOrg.Name = "panelOrg";
            this.panelOrg.Size = new Size(400, 200);
            this.panelOrg.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = Color.Transparent;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.Location = new Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(127, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Organization";
            // 
            // lblOrgName
            // 
            this.lblOrgName.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.lblOrgName.BackColor = Color.Transparent;
            this.lblOrgName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.lblOrgName.Location = new Point(15, 55);
            this.lblOrgName.Name = "lblOrgName";
            this.lblOrgName.Size = new Size(370, 25);
            this.lblOrgName.TabIndex = 1;
            this.lblOrgName.Text = "[Organization Name]";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.lblCreatedAt.BackColor = Color.Transparent;
            this.lblCreatedAt.Font = new Font("Segoe UI", 9.75F);
            this.lblCreatedAt.ForeColor = Color.Gray;
            this.lblCreatedAt.Location = new Point(17, 90);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new Size(370, 20);
            this.lblCreatedAt.TabIndex = 2;
            this.lblCreatedAt.Text = "Created: [Date]";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.DisabledState.BorderColor = Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.FillColor = Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.Font = new Font("Segoe UI", 10F);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(285, 145);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(100, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Org";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // OrganizationInfoControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.panelOrg);
            this.Name = "OrganizationInfoControl";
            this.Size = new Size(400, 200);
            this.panelOrg.ResumeLayout(false);
            this.panelOrg.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panelOrg;
        private Label lblTitle;
        private Label lblOrgName;
        private Label lblCreatedAt;
        private Guna2Button btnDelete;
    }
}
