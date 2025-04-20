using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;

namespace ims.UI.Forms
{
    partial class InviteUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblEmail = new Label();
            this.txtEmail = new Guna2TextBox();
            this.lblRole = new Label();
            this.cmbRole = new Guna2ComboBox();
            this.btnInviteUser = new Guna2Button();
            this.btnCancel = new Guna2Button();
            this.lblDescription = new Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(136, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(129, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Invite a User";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(53, 129);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(73, 13);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email Address";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.Cursor = Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.Parent = this.txtEmail;
            this.txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.FocusedState.Parent = this.txtEmail;
            this.txtEmail.Font = new Font("Segoe UI", 9F);
            this.txtEmail.HoverState.BorderColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.HoverState.Parent = this.txtEmail;
            this.txtEmail.Location = new Point(56, 145);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "Enter user\'s email address";
            this.txtEmail.SelectedText = "";
            this.txtEmail.ShadowDecoration.Parent = this.txtEmail;
            this.txtEmail.Size = new Size(287, 36);
            this.txtEmail.TabIndex = 2;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new Point(53, 194);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new Size(29, 13);
            this.lblRole.TabIndex = 3;
            this.lblRole.Text = "Role";
            // 
            // cmbRole
            // 
            this.cmbRole.BackColor = Color.Transparent;
            this.cmbRole.BorderRadius = 5;
            this.cmbRole.DrawMode = DrawMode.OwnerDrawFixed;
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.FocusedColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbRole.FocusedState.BorderColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbRole.FocusedState.Parent = this.cmbRole;
            this.cmbRole.Font = new Font("Segoe UI", 10F);
            this.cmbRole.ForeColor = Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbRole.HoverState.Parent = this.cmbRole;
            this.cmbRole.ItemHeight = 30;
            this.cmbRole.ItemsAppearance.Parent = this.cmbRole;
            this.cmbRole.Location = new Point(56, 210);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.ShadowDecoration.Parent = this.cmbRole;
            this.cmbRole.Size = new Size(287, 36);
            this.cmbRole.TabIndex = 4;
            // 
            // btnInviteUser
            // 
            this.btnInviteUser.BorderRadius = 5;
            this.btnInviteUser.CheckedState.Parent = this.btnInviteUser;
            this.btnInviteUser.CustomImages.Parent = this.btnInviteUser;
            this.btnInviteUser.FillColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnInviteUser.Font = new Font("Segoe UI", 9F);
            this.btnInviteUser.ForeColor = Color.White;
            this.btnInviteUser.HoverState.Parent = this.btnInviteUser;
            this.btnInviteUser.Location = new Point(236, 275);
            this.btnInviteUser.Name = "btnInviteUser";
            this.btnInviteUser.ShadowDecoration.Parent = this.btnInviteUser;
            this.btnInviteUser.Size = new Size(107, 36);
            this.btnInviteUser.TabIndex = 5;
            this.btnInviteUser.Text = "Send Invitation";
            this.btnInviteUser.Click += new System.EventHandler(this.BtnInviteUser_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = Color.Gray;
            this.btnCancel.Font = new Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new Point(123, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new Size(107, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new Point(56, 70);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(287, 46);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Enter the user\'s email address and select their role. An invitation email with a ve" +
    "rification code will be sent to them.";
            this.lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InviteUserForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(400, 350);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInviteUser);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InviteUserForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Invite User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTitle;
        private Label lblEmail;
        private Guna2TextBox txtEmail;
        private Label lblRole;
        private Guna2ComboBox cmbRole;
        private Guna2Button btnInviteUser;
        private Guna2Button btnCancel;
        private Label lblDescription;
    }
}
