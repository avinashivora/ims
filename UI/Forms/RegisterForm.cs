using System;
using System.Windows.Forms;
using ims.Services;
using ims.Utils;

namespace ims.UI.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly AuthService _authService;
        private readonly EmailService _emailService;
        private string _verificationCode;
        private string _email;
        private bool _isCodeVerified = false;

        public RegisterForm()
        {
            InitializeComponent();
            _authService = ServiceResolver.GetAuthService();
            _emailService = ServiceResolver.GetEmailService();

            // Initialize UI state
            pnlVerification.Visible = false;
            pnlCreateAccount.Visible = false;
            pnlEmail.Visible = true;
        }

        private async void BtnRequestCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _email = txtEmail.Text.Trim();

            try
            {
                // Generate and send verification code
                _verificationCode = _authService.GenerateCode();
                await _emailService.SendSignupCodeAsync(_email, _verificationCode);

                // Show verification panel
                pnlEmail.Visible = false;
                pnlVerification.Visible = true;
                lblVerificationEmail.Text = $"Verification code sent to {_email}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error requesting verification code: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerifyCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVerificationCode.Text))
            {
                MessageBox.Show("Please enter the verification code", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string enteredCode = txtVerificationCode.Text.Trim();

            if (enteredCode == _verificationCode)
            {
                _isCodeVerified = true;
                pnlVerification.Visible = false;
                pnlCreateAccount.Visible = true;
            }
            else
            {
                MessageBox.Show("Invalid verification code. Please try again.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!_isCodeVerified)
            {
                MessageBox.Show("Please verify your email first", "Verification Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords don't match or are empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtOrganizationName.Text))
            {
                MessageBox.Show("Organization name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Use the correct method with the current version of the service
                var (success, message, user) = await _authService.CompleteAdminRegistrationAsync(_email, _verificationCode, txtPassword.Text, txtOrganizationName.Text);

                if (success)
                {
                    MessageBox.Show("Admin account created successfully! You can now log in.", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Navigate to login form
                    this.Hide();
                    LoginForm loginForm = new();
                    loginForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Error creating account: {message}", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating account: {ex.Message}", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (pnlVerification.Visible)
            {
                pnlVerification.Visible = false;
                pnlEmail.Visible = true;
            }
            else if (pnlCreateAccount.Visible)
            {
                pnlCreateAccount.Visible = false;
                pnlVerification.Visible = true;
            }
        }

        private void LnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}