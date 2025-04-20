using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;

namespace ims.UI.Forms
{
    partial class PasswordResetForm
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
            this.pnlRequestReset = new Guna2Panel();
            this.lnkBack = new LinkLabel();
            this.btnRequestReset = new Guna2Button();
            this.txtEmail = new Guna2TextBox();
            this.lblResetInstructions = new Label();
            this.lblResetTitle = new Label();
            this.pnlVerifyCode = new Guna2Panel();
            this.lnkBackToRequest = new LinkLabel();
            this.btnVerifyCode = new Guna2Button();
            this.txtResetCode = new Guna2TextBox();
            this.lblVerifyInstructions = new Label();
            this.lblVerifyTitle = new Label();
            this.pnlResetPassword = new Guna2Panel();
            this.lnkBackToVerify = new LinkLabel();
            this.txtConfirmPassword = new Guna2TextBox();
            this.btnResetPassword = new Guna2Button();
            this.txtNewPassword = new Guna2TextBox();
            this.lblNewPasswordInstructions = new Label();
            this.lblNewPasswordTitle = new Label();
            this.pnlRequestReset.SuspendLayout();
            this.pnlVerifyCode.SuspendLayout();
            this.pnlResetPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRequestReset
            // 
            this.pnlRequestReset.BorderRadius = 10;
            this.pnlRequestReset.Controls.Add(this.lnkBack);
            this.pnlRequestReset.Controls.Add(this.btnRequestReset);
            this.pnlRequestReset.Controls.Add(this.txtEmail);
            this.pnlRequestReset.Controls.Add(this.lblResetInstructions);
            this.pnlRequestReset.Controls.Add(this.lblResetTitle);
            this.pnlRequestReset.FillColor = System.Drawing.Color.White;
            this.pnlRequestReset.Location = new System.Drawing.Point(75, 77);
            this.pnlRequestReset.Margin = new Padding(4, 5, 4, 5);
            this.pnlRequestReset.Name = "pnlRequestReset";
            this.pnlRequestReset.Size = new System.Drawing.Size(600, 538);
            this.pnlRequestReset.TabIndex = 0;
            // 
            // lnkBack
            // 
            this.lnkBack.AutoSize = true;
            this.lnkBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkBack.Location = new System.Drawing.Point(225, 462);
            this.lnkBack.Margin = new Padding(4, 0, 4, 0);
            this.lnkBack.Name = "lnkBack";
            this.lnkBack.Size = new System.Drawing.Size(119, 25);
            this.lnkBack.TabIndex = 4;
            this.lnkBack.TabStop = true;
            this.lnkBack.Text = "Back to Login";
            this.lnkBack.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LnkBack_LinkClicked);
            // 
            // btnRequestReset
            // 
            this.btnRequestReset.BorderRadius = 5;
            this.btnRequestReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRequestReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRequestReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRequestReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRequestReset.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(99)))), ((int)(((byte)(225)))));
            this.btnRequestReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRequestReset.ForeColor = System.Drawing.Color.White;
            this.btnRequestReset.Location = new System.Drawing.Point(75, 385);
            this.btnRequestReset.Margin = new Padding(4, 5, 4, 5);
            this.btnRequestReset.Name = "btnRequestReset";
            this.btnRequestReset.Size = new System.Drawing.Size(450, 62);
            this.btnRequestReset.TabIndex = 3;
            this.btnRequestReset.Text = "Send Reset Code";
            this.btnRequestReset.Click += new System.EventHandler(this.BtnRequestReset_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.Cursor = Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(75, 277);
            this.txtEmail.Margin = new Padding(6, 8, 6, 8);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Enter your email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(450, 62);
            this.txtEmail.TabIndex = 2;
            // 
            // lblResetInstructions
            // 
            this.lblResetInstructions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResetInstructions.Location = new System.Drawing.Point(75, 138);
            this.lblResetInstructions.Margin = new Padding(4, 0, 4, 0);
            this.lblResetInstructions.Name = "lblResetInstructions";
            this.lblResetInstructions.Size = new System.Drawing.Size(450, 123);
            this.lblResetInstructions.TabIndex = 1;
            this.lblResetInstructions.Text = "Enter your email address below. We\'ll send you a code to reset your password.";
            this.lblResetInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResetTitle
            // 
            this.lblResetTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblResetTitle.Location = new System.Drawing.Point(75, 46);
            this.lblResetTitle.Margin = new Padding(4, 0, 4, 0);
            this.lblResetTitle.Name = "lblResetTitle";
            this.lblResetTitle.Size = new System.Drawing.Size(450, 77);
            this.lblResetTitle.TabIndex = 0;
            this.lblResetTitle.Text = "Reset Password";
            this.lblResetTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlVerifyCode
            // 
            this.pnlVerifyCode.BorderRadius = 10;
            this.pnlVerifyCode.Controls.Add(this.lnkBackToRequest);
            this.pnlVerifyCode.Controls.Add(this.btnVerifyCode);
            this.pnlVerifyCode.Controls.Add(this.txtResetCode);
            this.pnlVerifyCode.Controls.Add(this.lblVerifyInstructions);
            this.pnlVerifyCode.Controls.Add(this.lblVerifyTitle);
            this.pnlVerifyCode.FillColor = System.Drawing.Color.White;
            this.pnlVerifyCode.Location = new System.Drawing.Point(75, 77);
            this.pnlVerifyCode.Margin = new Padding(4, 5, 4, 5);
            this.pnlVerifyCode.Name = "pnlVerifyCode";
            this.pnlVerifyCode.Size = new System.Drawing.Size(600, 538);
            this.pnlVerifyCode.TabIndex = 1;
            this.pnlVerifyCode.Visible = false;
            // 
            // lnkBackToRequest
            // 
            this.lnkBackToRequest.AutoSize = true;
            this.lnkBackToRequest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkBackToRequest.Location = new System.Drawing.Point(225, 462);
            this.lnkBackToRequest.Margin = new Padding(4, 0, 4, 0);
            this.lnkBackToRequest.Name = "lnkBackToRequest";
            this.lnkBackToRequest.Size = new System.Drawing.Size(138, 25);
            this.lnkBackToRequest.TabIndex = 4;
            this.lnkBackToRequest.TabStop = true;
            this.lnkBackToRequest.Text = "Back to Request";
            this.lnkBackToRequest.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LnkBackToRequest_LinkClicked);
            // 
            // btnVerifyCode
            // 
            this.btnVerifyCode.BorderRadius = 5;
            this.btnVerifyCode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVerifyCode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVerifyCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVerifyCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVerifyCode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(99)))), ((int)(((byte)(225)))));
            this.btnVerifyCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVerifyCode.ForeColor = System.Drawing.Color.White;
            this.btnVerifyCode.Location = new System.Drawing.Point(75, 385);
            this.btnVerifyCode.Margin = new Padding(4, 5, 4, 5);
            this.btnVerifyCode.Name = "btnVerifyCode";
            this.btnVerifyCode.Size = new System.Drawing.Size(450, 62);
            this.btnVerifyCode.TabIndex = 3;
            this.btnVerifyCode.Text = "Verify Code";
            this.btnVerifyCode.Click += new System.EventHandler(this.BtnVerifyCode_Click);
            // 
            // txtResetCode
            // 
            this.txtResetCode.BorderRadius = 5;
            this.txtResetCode.Cursor = Cursors.IBeam;
            this.txtResetCode.DefaultText = "";
            this.txtResetCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtResetCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtResetCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtResetCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtResetCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtResetCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtResetCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtResetCode.Location = new System.Drawing.Point(75, 277);
            this.txtResetCode.Margin = new Padding(6, 8, 6, 8);
            this.txtResetCode.MaxLength = 6;
            this.txtResetCode.Name = "txtResetCode";
            this.txtResetCode.PlaceholderText = "Enter 6-digit code";
            this.txtResetCode.SelectedText = "";
            this.txtResetCode.Size = new System.Drawing.Size(450, 62);
            this.txtResetCode.TabIndex = 2;
            // 
            // lblVerifyInstructions
            // 
            this.lblVerifyInstructions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVerifyInstructions.Location = new System.Drawing.Point(75, 138);
            this.lblVerifyInstructions.Margin = new Padding(4, 0, 4, 0);
            this.lblVerifyInstructions.Name = "lblVerifyInstructions";
            this.lblVerifyInstructions.Size = new System.Drawing.Size(450, 123);
            this.lblVerifyInstructions.TabIndex = 1;
            this.lblVerifyInstructions.Text = "Please enter the 6-digit code that was sent to your email address. This code will" +
    " expire in 1 hour.";
            this.lblVerifyInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVerifyTitle
            // 
            this.lblVerifyTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblVerifyTitle.Location = new System.Drawing.Point(75, 46);
            this.lblVerifyTitle.Margin = new Padding(4, 0, 4, 0);
            this.lblVerifyTitle.Name = "lblVerifyTitle";
            this.lblVerifyTitle.Size = new System.Drawing.Size(450, 77);
            this.lblVerifyTitle.TabIndex = 0;
            this.lblVerifyTitle.Text = "Verify Code";
            this.lblVerifyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlResetPassword
            // 
            this.pnlResetPassword.BorderRadius = 10;
            this.pnlResetPassword.Controls.Add(this.lnkBackToVerify);
            this.pnlResetPassword.Controls.Add(this.txtConfirmPassword);
            this.pnlResetPassword.Controls.Add(this.btnResetPassword);
            this.pnlResetPassword.Controls.Add(this.txtNewPassword);
            this.pnlResetPassword.Controls.Add(this.lblNewPasswordInstructions);
            this.pnlResetPassword.Controls.Add(this.lblNewPasswordTitle);
            this.pnlResetPassword.FillColor = System.Drawing.Color.White;
            this.pnlResetPassword.Location = new System.Drawing.Point(75, 77);
            this.pnlResetPassword.Margin = new Padding(4, 5, 4, 5);
            this.pnlResetPassword.Name = "pnlResetPassword";
            this.pnlResetPassword.Size = new System.Drawing.Size(600, 615);
            this.pnlResetPassword.TabIndex = 2;
            this.pnlResetPassword.Visible = false;
            // 
            // lnkBackToVerify
            // 
            this.lnkBackToVerify.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.lnkBackToVerify.AutoSize = true;
            this.lnkBackToVerify.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkBackToVerify.Location = new System.Drawing.Point(225, 538);
            this.lnkBackToVerify.Margin = new Padding(4, 0, 4, 0);
            this.lnkBackToVerify.Name = "lnkBackToVerify";
            this.lnkBackToVerify.Size = new System.Drawing.Size(162, 25);
            this.lnkBackToVerify.TabIndex = 5;
            this.lnkBackToVerify.TabStop = true;
            this.lnkBackToVerify.Text = "Back to Verification";
            this.lnkBackToVerify.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkBackToVerify.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LnkBackToVerify_LinkClicked);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderRadius = 5;
            this.txtConfirmPassword.Cursor = Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(75, 354);
            this.txtConfirmPassword.Margin = new Padding(6, 8, 6, 8);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.PlaceholderText = "Confirm new password";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.Size = new System.Drawing.Size(450, 62);
            this.txtConfirmPassword.TabIndex = 4;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BorderRadius = 5;
            this.btnResetPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResetPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResetPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResetPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResetPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(99)))), ((int)(((byte)(225)))));
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.Location = new System.Drawing.Point(75, 462);
            this.btnResetPassword.Margin = new Padding(4, 5, 4, 5);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(450, 62);
            this.btnResetPassword.TabIndex = 3;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.Click += new System.EventHandler(this.BtnResetPassword_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BorderRadius = 5;
            this.txtNewPassword.Cursor = Cursors.IBeam;
            this.txtNewPassword.DefaultText = "";
            this.txtNewPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPassword.Location = new System.Drawing.Point(75, 277);
            this.txtNewPassword.Margin = new Padding(6, 8, 6, 8);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.PlaceholderText = "Enter new password";
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.Size = new System.Drawing.Size(450, 62);
            this.txtNewPassword.TabIndex = 2;
            // 
            // lblNewPasswordInstructions
            // 
            this.lblNewPasswordInstructions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewPasswordInstructions.Location = new System.Drawing.Point(75, 138);
            this.lblNewPasswordInstructions.Margin = new Padding(4, 0, 4, 0);
            this.lblNewPasswordInstructions.Name = "lblNewPasswordInstructions";
            this.lblNewPasswordInstructions.Size = new System.Drawing.Size(450, 123);
            this.lblNewPasswordInstructions.TabIndex = 1;
            this.lblNewPasswordInstructions.Text = "Please enter and confirm your new password.";
            this.lblNewPasswordInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNewPasswordTitle
            // 
            this.lblNewPasswordTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNewPasswordTitle.Location = new System.Drawing.Point(75, 46);
            this.lblNewPasswordTitle.Margin = new Padding(4, 0, 4, 0);
            this.lblNewPasswordTitle.Name = "lblNewPasswordTitle";
            this.lblNewPasswordTitle.Size = new System.Drawing.Size(450, 77);
            this.lblNewPasswordTitle.TabIndex = 0;
            this.lblNewPasswordTitle.Text = "Create New Password";
            this.lblNewPasswordTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordResetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(750, 692);
            this.Controls.Add(this.pnlRequestReset);
            this.Controls.Add(this.pnlVerifyCode);
            this.Controls.Add(this.pnlResetPassword);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Margin = new Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "PasswordResetForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Reset Password";
            this.pnlRequestReset.ResumeLayout(false);
            this.pnlRequestReset.PerformLayout();
            this.pnlVerifyCode.ResumeLayout(false);
            this.pnlVerifyCode.PerformLayout();
            this.pnlResetPassword.ResumeLayout(false);
            this.pnlResetPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2Panel pnlRequestReset;
        private Label lblResetTitle;
        private Label lblResetInstructions;
        private Guna2TextBox txtEmail;
        private Guna2Button btnRequestReset;
        private LinkLabel lnkBack;

        private Guna2Panel pnlVerifyCode;
        private Label lblVerifyTitle;
        private Label lblVerifyInstructions;
        private Guna2TextBox txtResetCode;
        private Guna2Button btnVerifyCode;
        private LinkLabel lnkBackToRequest;

        private Guna2Panel pnlResetPassword;
        private Label lblNewPasswordTitle;
        private Label lblNewPasswordInstructions;
        private Guna2TextBox txtNewPassword;
        private Guna2Button btnResetPassword;
        private Guna2TextBox txtConfirmPassword;
        private LinkLabel lnkBackToVerify;
    }
}
