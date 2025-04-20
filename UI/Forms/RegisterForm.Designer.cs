using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;

namespace ims.UI.Forms
{
    partial class RegisterForm
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
            this.pnlEmail = new Guna2Panel();
            this.lnkLogin = new LinkLabel();
            this.lblLoginPrompt = new Label();
            this.btnRequestCode = new Guna2Button();
            this.txtEmail = new Guna2TextBox();
            this.lblEmail = new Label();
            this.lblRegisterTitle = new Label();
            this.pnlVerification = new Guna2Panel();
            this.btnBackToEmail = new Guna2Button();
            this.lblVerificationEmail = new Label();
            this.btnVerifyCode = new Guna2Button();
            this.txtVerificationCode = new Guna2TextBox();
            this.lblVerificationCode = new Label();
            this.lblVerificationTitle = new Label();
            this.pnlCreateAccount = new Guna2Panel();
            this.txtOrganizationName = new Guna2TextBox();
            this.lblOrganizationName = new Label();
            this.btnBackToVerification = new Guna2Button();
            this.btnCreateAccount = new Guna2Button();
            this.txtConfirmPassword = new Guna2TextBox();
            this.lblConfirmPassword = new Label();
            this.txtPassword = new Guna2TextBox();
            this.lblPassword = new Label();
            this.lblCreateAccountTitle = new Label();
            this.pnlEmail.SuspendLayout();
            this.pnlVerification.SuspendLayout();
            this.pnlCreateAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEmail
            // 
            this.pnlEmail.BackColor = Color.White;
            this.pnlEmail.Controls.Add(this.lnkLogin);
            this.pnlEmail.Controls.Add(this.lblLoginPrompt);
            this.pnlEmail.Controls.Add(this.btnRequestCode);
            this.pnlEmail.Controls.Add(this.txtEmail);
            this.pnlEmail.Controls.Add(this.lblEmail);
            this.pnlEmail.Controls.Add(this.lblRegisterTitle);
            this.pnlEmail.Location = new Point(12, 12);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.ShadowDecoration.Parent = this.pnlEmail;
            this.pnlEmail.Size = new Size(460, 326);
            this.pnlEmail.TabIndex = 0;
            // 
            // lnkLogin
            // 
            this.lnkLogin.AutoSize = true;
            this.lnkLogin.Location = new Point(272, 264);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new Size(37, 13);
            this.lnkLogin.TabIndex = 5;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Log in";
            this.lnkLogin.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LnkLogin_LinkClicked);
            // 
            // lblLoginPrompt
            // 
            this.lblLoginPrompt.AutoSize = true;
            this.lblLoginPrompt.Location = new Point(153, 264);
            this.lblLoginPrompt.Name = "lblLoginPrompt";
            this.lblLoginPrompt.Size = new Size(113, 13);
            this.lblLoginPrompt.TabIndex = 4;
            this.lblLoginPrompt.Text = "Already have account?";
            // 
            // btnRequestCode
            // 
            this.btnRequestCode.BorderRadius = 5;
            this.btnRequestCode.CheckedState.Parent = this.btnRequestCode;
            this.btnRequestCode.CustomImages.Parent = this.btnRequestCode;
            this.btnRequestCode.FillColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRequestCode.Font = new Font("Segoe UI", 9F);
            this.btnRequestCode.ForeColor = Color.White;
            this.btnRequestCode.HoverState.Parent = this.btnRequestCode;
            this.btnRequestCode.Location = new Point(156, 211);
            this.btnRequestCode.Name = "btnRequestCode";
            this.btnRequestCode.ShadowDecoration.Parent = this.btnRequestCode;
            this.btnRequestCode.Size = new Size(153, 36);
            this.btnRequestCode.TabIndex = 3;
            this.btnRequestCode.Text = "Request Verification Code";
            this.btnRequestCode.Click += new System.EventHandler(this.BtnRequestCode_Click);
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
            this.txtEmail.Location = new Point(103, 153);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "Enter your email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.ShadowDecoration.Parent = this.txtEmail;
            this.txtEmail.Size = new Size(258, 36);
            this.txtEmail.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(103, 137);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(32, 13);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email";
            // 
            // lblRegisterTitle
            // 
            this.lblRegisterTitle.AutoSize = true;
            this.lblRegisterTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisterTitle.Location = new Point(129, 77);
            this.lblRegisterTitle.Name = "lblRegisterTitle";
            this.lblRegisterTitle.Size = new Size(204, 30);
            this.lblRegisterTitle.TabIndex = 0;
            this.lblRegisterTitle.Text = "Register New Admin";
            // 
            // pnlVerification
            // 
            this.pnlVerification.BackColor = Color.White;
            this.pnlVerification.Controls.Add(this.btnBackToEmail);
            this.pnlVerification.Controls.Add(this.lblVerificationEmail);
            this.pnlVerification.Controls.Add(this.btnVerifyCode);
            this.pnlVerification.Controls.Add(this.txtVerificationCode);
            this.pnlVerification.Controls.Add(this.lblVerificationCode);
            this.pnlVerification.Controls.Add(this.lblVerificationTitle);
            this.pnlVerification.Location = new Point(12, 12);
            this.pnlVerification.Name = "pnlVerification";
            this.pnlVerification.ShadowDecoration.Parent = this.pnlVerification;
            this.pnlVerification.Size = new Size(460, 326);
            this.pnlVerification.TabIndex = 6;
            // 
            // btnBackToEmail
            // 
            this.btnBackToEmail.BorderRadius = 5;
            this.btnBackToEmail.CheckedState.Parent = this.btnBackToEmail;
            this.btnBackToEmail.CustomImages.Parent = this.btnBackToEmail;
            this.btnBackToEmail.FillColor = Color.Gray;
            this.btnBackToEmail.Font = new Font("Segoe UI", 9F);
            this.btnBackToEmail.ForeColor = Color.White;
            this.btnBackToEmail.HoverState.Parent = this.btnBackToEmail;
            this.btnBackToEmail.Location = new Point(156, 261);
            this.btnBackToEmail.Name = "btnBackToEmail";
            this.btnBackToEmail.ShadowDecoration.Parent = this.btnBackToEmail;
            this.btnBackToEmail.Size = new Size(153, 36);
            this.btnBackToEmail.TabIndex = 5;
            this.btnBackToEmail.Text = "Back";
            this.btnBackToEmail.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // lblVerificationEmail
            // 
            this.lblVerificationEmail.AutoSize = true;
            this.lblVerificationEmail.Location = new Point(103, 107);
            this.lblVerificationEmail.Name = "lblVerificationEmail";
            this.lblVerificationEmail.Size = new Size(137, 13);
            this.lblVerificationEmail.TabIndex = 4;
            this.lblVerificationEmail.Text = "Verification code sent to: ...";
            // 
            // btnVerifyCode
            // 
            this.btnVerifyCode.BorderRadius = 5;
            this.btnVerifyCode.CheckedState.Parent = this.btnVerifyCode;
            this.btnVerifyCode.CustomImages.Parent = this.btnVerifyCode;
            this.btnVerifyCode.FillColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnVerifyCode.Font = new Font("Segoe UI", 9F);
            this.btnVerifyCode.ForeColor = Color.White;
            this.btnVerifyCode.HoverState.Parent = this.btnVerifyCode;
            this.btnVerifyCode.Location = new Point(156, 211);
            this.btnVerifyCode.Name = "btnVerifyCode";
            this.btnVerifyCode.ShadowDecoration.Parent = this.btnVerifyCode;
            this.btnVerifyCode.Size = new Size(153, 36);
            this.btnVerifyCode.TabIndex = 3;
            this.btnVerifyCode.Text = "Verify Code";
            this.btnVerifyCode.Click += new System.EventHandler(this.BtnVerifyCode_Click);
            // 
            // txtVerificationCode
            // 
            this.txtVerificationCode.BorderRadius = 5;
            this.txtVerificationCode.Cursor = Cursors.IBeam;
            this.txtVerificationCode.DefaultText = "";
            this.txtVerificationCode.DisabledState.BorderColor = Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtVerificationCode.DisabledState.FillColor = Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtVerificationCode.DisabledState.ForeColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVerificationCode.DisabledState.Parent = this.txtVerificationCode;
            this.txtVerificationCode.DisabledState.PlaceholderForeColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVerificationCode.FocusedState.BorderColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVerificationCode.FocusedState.Parent = this.txtVerificationCode;
            this.txtVerificationCode.Font = new Font("Segoe UI", 9F);
            this.txtVerificationCode.HoverState.BorderColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVerificationCode.HoverState.Parent = this.txtVerificationCode;
            this.txtVerificationCode.Location = new Point(103, 153);
            this.txtVerificationCode.Name = "txtVerificationCode";
            this.txtVerificationCode.PasswordChar = '\0';
            this.txtVerificationCode.PlaceholderText = "Enter 6-digit code";
            this.txtVerificationCode.SelectedText = "";
            this.txtVerificationCode.ShadowDecoration.Parent = this.txtVerificationCode;
            this.txtVerificationCode.Size = new Size(258, 36);
            this.txtVerificationCode.TabIndex = 2;
            // 
            // lblVerificationCode
            // 
            this.lblVerificationCode.AutoSize = true;
            this.lblVerificationCode.Location = new Point(103, 137);
            this.lblVerificationCode.Name = "lblVerificationCode";
            this.lblVerificationCode.Size = new Size(89, 13);
            this.lblVerificationCode.TabIndex = 1;
            this.lblVerificationCode.Text = "Verification Code";
            // 
            // lblVerificationTitle
            // 
            this.lblVerificationTitle.AutoSize = true;
            this.lblVerificationTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblVerificationTitle.Location = new Point(143, 59);
            this.lblVerificationTitle.Name = "lblVerificationTitle";
            this.lblVerificationTitle.Size = new Size(178, 30);
            this.lblVerificationTitle.TabIndex = 0;
            this.lblVerificationTitle.Text = "Verify Your Email";
            // 
            // pnlCreateAccount
            // 
            this.pnlCreateAccount.BackColor = Color.White;
            this.pnlCreateAccount.Controls.Add(this.txtOrganizationName);
            this.pnlCreateAccount.Controls.Add(this.lblOrganizationName);
            this.pnlCreateAccount.Controls.Add(this.btnBackToVerification);
            this.pnlCreateAccount.Controls.Add(this.btnCreateAccount);
            this.pnlCreateAccount.Controls.Add(this.txtConfirmPassword);
            this.pnlCreateAccount.Controls.Add(this.lblConfirmPassword);
            this.pnlCreateAccount.Controls.Add(this.txtPassword);
            this.pnlCreateAccount.Controls.Add(this.lblPassword);
            this.pnlCreateAccount.Controls.Add(this.lblCreateAccountTitle);
            this.pnlCreateAccount.Location = new Point(12, 12);
            this.pnlCreateAccount.Name = "pnlCreateAccount";
            this.pnlCreateAccount.ShadowDecoration.Parent = this.pnlCreateAccount;
            this.pnlCreateAccount.Size = new Size(460, 388);
            this.pnlCreateAccount.TabIndex = 7;
            // 
            // txtOrganizationName
            // 
            this.txtOrganizationName.BorderRadius = 5;
            this.txtOrganizationName.Cursor = Cursors.IBeam;
            this.txtOrganizationName.DefaultText = "";
            this.txtOrganizationName.DisabledState.BorderColor = Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOrganizationName.DisabledState.FillColor = Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOrganizationName.DisabledState.ForeColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOrganizationName.DisabledState.Parent = this.txtOrganizationName;
            this.txtOrganizationName.DisabledState.PlaceholderForeColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOrganizationName.FocusedState.BorderColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOrganizationName.FocusedState.Parent = this.txtOrganizationName;
            this.txtOrganizationName.Font = new Font("Segoe UI", 9F);
            this.txtOrganizationName.HoverState.BorderColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOrganizationName.HoverState.Parent = this.txtOrganizationName;
            this.txtOrganizationName.Location = new Point(103, 229);
            this.txtOrganizationName.Name = "txtOrganizationName";
            this.txtOrganizationName.PasswordChar = '\0';
            this.txtOrganizationName.PlaceholderText = "Enter organization name";
            this.txtOrganizationName.SelectedText = "";
            this.txtOrganizationName.ShadowDecoration.Parent = this.txtOrganizationName;
            this.txtOrganizationName.Size = new Size(258, 36);
            this.txtOrganizationName.TabIndex = 8;
            // 
            // lblOrganizationName
            // 
            this.lblOrganizationName.AutoSize = true;
            this.lblOrganizationName.Location = new Point(103, 213);
            this.lblOrganizationName.Name = "lblOrganizationName";
            this.lblOrganizationName.Size = new Size(97, 13);
            this.lblOrganizationName.TabIndex = 7;
            this.lblOrganizationName.Text = "Organization Name";
            // 
            // btnBackToVerification
            // 
            this.btnBackToVerification.BorderRadius = 5;
            this.btnBackToVerification.CheckedState.Parent = this.btnBackToVerification;
            this.btnBackToVerification.CustomImages.Parent = this.btnBackToVerification;
            this.btnBackToVerification.FillColor = Color.Gray;
            this.btnBackToVerification.Font = new Font("Segoe UI", 9F);
            this.btnBackToVerification.ForeColor = Color.White;
            this.btnBackToVerification.HoverState.Parent = this.btnBackToVerification;
            this.btnBackToVerification.Location = new Point(103, 323);
            this.btnBackToVerification.Name = "btnBackToVerification";
            this.btnBackToVerification.ShadowDecoration.Parent = this.btnBackToVerification;
            this.btnBackToVerification.Size = new Size(107, 36);
            this.btnBackToVerification.TabIndex = 6;
            this.btnBackToVerification.Text = "Back";
            this.btnBackToVerification.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.BorderRadius = 5;
            this.btnCreateAccount.CheckedState.Parent = this.btnCreateAccount;
            this.btnCreateAccount.CustomImages.Parent = this.btnCreateAccount;
            this.btnCreateAccount.FillColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCreateAccount.Font = new Font("Segoe UI", 9F);
            this.btnCreateAccount.ForeColor = Color.White;
            this.btnCreateAccount.HoverState.Parent = this.btnCreateAccount;
            this.btnCreateAccount.Location = new Point(216, 323);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.ShadowDecoration.Parent = this.btnCreateAccount;
            this.btnCreateAccount.Size = new Size(145, 36);
            this.btnCreateAccount.TabIndex = 5;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.Click += new System.EventHandler(this.BtnCreateAccount_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderRadius = 5;
            this.txtConfirmPassword.Cursor = Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.DisabledState.BorderColor = Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPassword.DisabledState.FillColor = Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPassword.DisabledState.ForeColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.DisabledState.Parent = this.txtConfirmPassword;
            this.txtConfirmPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.FocusedState.BorderColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.FocusedState.Parent = this.txtConfirmPassword;
            this.txtConfirmPassword.Font = new Font("Segoe UI", 9F);
            this.txtConfirmPassword.HoverState.BorderColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.HoverState.Parent = this.txtConfirmPassword;
            this.txtConfirmPassword.Location = new Point(103, 173);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.PlaceholderText = "Confirm your password";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.ShadowDecoration.Parent = this.txtConfirmPassword;
            this.txtConfirmPassword.Size = new Size(258, 36);
            this.txtConfirmPassword.TabIndex = 4;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new Point(103, 157);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new Size(91, 13);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 5;
            this.txtPassword.Cursor = Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.Parent = this.txtPassword;
            this.txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.FocusedState.Parent = this.txtPassword;
            this.txtPassword.Font = new Font("Segoe UI", 9F);
            this.txtPassword.HoverState.BorderColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.HoverState.Parent = this.txtPassword;
            this.txtPassword.Location = new Point(103, 113);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "Enter your password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.ShadowDecoration.Parent = this.txtPassword;
            this.txtPassword.Size = new Size(258, 36);
            this.txtPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(103, 97);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(53, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // lblCreateAccountTitle
            // 
            this.lblCreateAccountTitle.AutoSize = true;
            this.lblCreateAccountTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateAccountTitle.Location = new Point(126, 39);
            this.lblCreateAccountTitle.Name = "lblCreateAccountTitle";
            this.lblCreateAccountTitle.Size = new Size(213, 30);
            this.lblCreateAccountTitle.TabIndex = 0;
            this.lblCreateAccountTitle.Text = "Create Admin Profile";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(484, 411);
            this.Controls.Add(this.pnlEmail);
            this.Controls.Add(this.pnlVerification);
            this.Controls.Add(this.pnlCreateAccount);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "IMS - Admin Registration";
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            this.pnlVerification.ResumeLayout(false);
            this.pnlVerification.PerformLayout();
            this.pnlCreateAccount.ResumeLayout(false);
            this.pnlCreateAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2Panel pnlEmail;
        private LinkLabel lnkLogin;
        private Label lblLoginPrompt;
        private Guna2Button btnRequestCode;
        private Guna2TextBox txtEmail;
        private Label lblEmail;
        private Label lblRegisterTitle;
        private Guna2Panel pnlVerification;
        private Guna2Button btnBackToEmail;
        private Label lblVerificationEmail;
        private Guna2Button btnVerifyCode;
        private Guna2TextBox txtVerificationCode;
        private Label lblVerificationCode;
        private Label lblVerificationTitle;
        private Guna2Panel pnlCreateAccount;
        private Guna2TextBox txtOrganizationName;
        private Label lblOrganizationName;
        private Guna2Button btnBackToVerification;
        private Guna2Button btnCreateAccount;
        private Guna2TextBox txtConfirmPassword;
        private Label lblConfirmPassword;
        private Guna2TextBox txtPassword;
        private Label lblPassword;
        private Label lblCreateAccountTitle;
    }
}
