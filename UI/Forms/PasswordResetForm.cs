using System;
using System.Windows.Forms;
using ims.Services;
using ims.Utils;

namespace ims.UI.Forms
{
    public partial class PasswordResetForm : Form
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;
        private readonly EmailService _emailService;
        private string _email;
        private string _verificationCode;
        private bool _codeVerified = false;

        public PasswordResetForm()
        {
            InitializeComponent();
            _authService = ServiceResolver.GetAuthService();
            _userService = ServiceResolver.GetUserService();
            _emailService = ServiceResolver.GetEmailService();

            // Initial form state
            pnlResetPassword.Visible = false;
            pnlVerifyCode.Visible = false;
            pnlRequestReset.Visible = true;
        }

        private void BtnRequestReset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter your email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _email = txtEmail.Text.Trim();

            try
            {
                var user = _userService.GetUserByEmailAsync(_email);
                if (user == null)
                {
                    MessageBox.Show("No account found with this email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Generate and save reset code
                var resetCode = _authService.GenerateCode();

                // Send email with reset code
                _ = _emailService.SendPasswordResetCodeAsync(_email, resetCode);

                MessageBox.Show("A password reset code has been sent to your email address.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Show code verification panel
                pnlRequestReset.Visible = false;
                pnlVerifyCode.Visible = true;
                txtResetCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnVerifyCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtResetCode.Text))
            {
                MessageBox.Show("Please enter the reset code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _verificationCode = txtResetCode.Text.Trim();

            try
            {
                bool isValid = await _authService.VerifyPasswordResetCodeAsync(_email, _verificationCode);
                if (!isValid)
                {
                    MessageBox.Show("Invalid or expired reset code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Code is valid, show password reset panel
                _codeVerified = true;
                pnlVerifyCode.Visible = false;
                pnlResetPassword.Visible = true;
                txtNewPassword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if (!_codeVerified)
            {
                MessageBox.Show("Code verification required before resetting password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Please enter a new password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _ = _authService.CompletePasswordResetAsync(_email, _verificationCode, txtNewPassword.Text);
                MessageBox.Show("Your password has been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close this form and open login form
                LoginForm loginForm = new();
                this.Hide();
                loginForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LnkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Return to login form
            LoginForm loginForm = new();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void LnkBackToRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Go back to the request panel
            pnlVerifyCode.Visible = false;
            pnlResetPassword.Visible = false;
            pnlRequestReset.Visible = true;
        }

        private void LnkBackToVerify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Go back to the verify code panel
            pnlResetPassword.Visible = false;
            pnlRequestReset.Visible = false;
            pnlVerifyCode.Visible = true;
        }
    }
}