using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.UI.Forms
{
    partial class CodeVerificationForm
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
            this.lblTitle = new Guna2HtmlLabel();
            this.lblInstructions = new Guna2HtmlLabel();
            this.lblVerificationCode = new Guna2HtmlLabel();
            this.txtVerificationCode = new Guna2TextBox();
            this.btnVerify = new Guna2Button();
            this.btnCancel = new Guna2Button();
            this.btnResendCode = new Guna2Button();
            this.guna2Panel1 = new Guna2Panel();
            this.guna2ShadowForm1 = new Guna2ShadowForm();
            this.guna2DragControl1 = new Guna2DragControl();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Verify Code";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInstructions
            // 
            this.lblInstructions.BackColor = System.Drawing.Color.Transparent;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInstructions.Location = new System.Drawing.Point(30, 70);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(380, 40);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = "Please enter the 6-digit code sent to your email.";
            this.lblInstructions.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblVerificationCode
            // 
            this.lblVerificationCode.BackColor = System.Drawing.Color.Transparent;
            this.lblVerificationCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerificationCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVerificationCode.Location = new System.Drawing.Point(30, 130);
            this.lblVerificationCode.Name = "lblVerificationCode";
            this.lblVerificationCode.Size = new System.Drawing.Size(120, 18);
            this.lblVerificationCode.TabIndex = 2;
            this.lblVerificationCode.Text = "Verification Code:";
            // 
            // txtVerificationCode
            // 
            this.txtVerificationCode.BorderRadius = 5;
            this.txtVerificationCode.Cursor = Cursors.IBeam;
            this.txtVerificationCode.DefaultText = "";
            this.txtVerificationCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtVerificationCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtVerificationCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVerificationCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVerificationCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVerificationCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVerificationCode.ForeColor = System.Drawing.Color.Black;
            this.txtVerificationCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVerificationCode.Location = new System.Drawing.Point(30, 155);
            this.txtVerificationCode.Margin = new Padding(4, 4, 4, 4);
            this.txtVerificationCode.MaxLength = 6;
            this.txtVerificationCode.Name = "txtVerificationCode";
            this.txtVerificationCode.PasswordChar = '\0';
            this.txtVerificationCode.PlaceholderText = "Enter 6-digit code";
            this.txtVerificationCode.SelectedText = "";
            this.txtVerificationCode.Size = new System.Drawing.Size(380, 50);
            this.txtVerificationCode.TabIndex = 3;
            this.txtVerificationCode.TextAlign = HorizontalAlignment.Center;
            // 
            // btnVerify
            // 
            this.btnVerify.BorderRadius = 5;
            this.btnVerify.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVerify.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVerify.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVerify.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVerify.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(220)))));
            this.btnVerify.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.Location = new System.Drawing.Point(230, 230);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(180, 45);
            this.btnVerify.TabIndex = 4;
            this.btnVerify.Text = "Verify";
            this.btnVerify.Click += new System.EventHandler(this.BtnVerify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Silver;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(30, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 45);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnResendCode
            // 
            this.btnResendCode.BorderRadius = 5;
            this.btnResendCode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResendCode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResendCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResendCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResendCode.FillColor = System.Drawing.Color.Transparent;
            this.btnResendCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResendCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(220)))));
            this.btnResendCode.Location = new System.Drawing.Point(30, 295);
            this.btnResendCode.Name = "btnResendCode";
            this.btnResendCode.Size = new System.Drawing.Size(180, 35);
            this.btnResendCode.TabIndex = 6;
            this.btnResendCode.Text = "Resend Code";
            this.btnResendCode.Click += new System.EventHandler(this.BtnResendCode_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.lblTitle);
            this.guna2Panel1.Controls.Add(this.btnResendCode);
            this.guna2Panel1.Controls.Add(this.lblInstructions);
            this.guna2Panel1.Controls.Add(this.btnCancel);
            this.guna2Panel1.Controls.Add(this.lblVerificationCode);
            this.guna2Panel1.Controls.Add(this.btnVerify);
            this.guna2Panel1.Controls.Add(this.txtVerificationCode);
            this.guna2Panel1.Dock = DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(440, 350);
            this.guna2Panel1.TabIndex = 7;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.guna2Panel1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // CodeVerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 350);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "CodeVerificationForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Verification Code";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2HtmlLabel lblTitle;
        private Guna2HtmlLabel lblInstructions;
        private Guna2HtmlLabel lblVerificationCode;
        private Guna2TextBox txtVerificationCode;
        private Guna2Button btnVerify;
        private Guna2Button btnCancel;
        private Guna2Button btnResendCode;
        private Guna2Panel guna2Panel1;
        private Guna2ShadowForm guna2ShadowForm1;
        private Guna2DragControl guna2DragControl1;
    }
}
