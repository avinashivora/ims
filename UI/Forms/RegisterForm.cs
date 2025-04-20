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
        private readonly OrganizationService _orgService;
        private string _verificationCode;
        private string _email;
        private bool _isCodeVerified = false;
        private string _userId;
        private readonly bool _isInvitedUser;

        // Modify constructor to handle invited user case
        public RegisterForm(bool invitedUser)
        {
            _isInvitedUser = invitedUser;

            InitializeComponent();
            _authService = ServiceResolver.GetAuthService();
            _emailService = ServiceResolver.GetEmailService();

            if (!invitedUser)
            {
                _orgService = ServiceResolver.GetOrganizationService();
            }

            // Initialize UI state
            pnlVerification.Visible = false;
            pnlCreateAccount.Visible = false;
            pnlEmail.Visible = true;

            // Update UI elements based on registration type
            if (invitedUser)
            {
                lblRegisterTitle.Text = "Complete Registration";
                btnRequestCode.Text = "Continue with Invite";
                lblLoginPrompt.Visible = false;
                lnkLogin.Visible = false;
            }
        }

        // Modify BtnRequestCode_Click method to handle invite flow
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
                if (_isInvitedUser)
                {
                    // For invited users, show the verification panel directly
                    // They should have already received a code
                    pnlEmail.Visible = false;
                    pnlVerification.Visible = true;
                    lblVerificationEmail.Text = $"Enter the invitation code sent to {_email}";
                    lblVerificationTitle.Text = "Enter Invitation Code";
                }
                else
                {
                    // For admin registration, generate and send a new verification code
                    _verificationCode = _authService.GenerateCode();
                    await _emailService.SendSignupCodeAsync(_email, _verificationCode);

                    // Show verification panel
                    pnlEmail.Visible = false;
                    pnlVerification.Visible = true;
                    lblVerificationEmail.Text = $"Verification code sent to {_email}";
                    var (success, message, uid) = await _authService.InitiateRegistrationAsync(_email);
                    _userId = uid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modify BtnVerifyCode_Click to handle invited user logic
        private void BtnVerifyCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVerificationCode.Text))
            {
                MessageBox.Show("Please enter the verification code", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string enteredCode = txtVerificationCode.Text.Trim();

            try
            {
                if (_isInvitedUser)
                {
                    try
                    {
                        _isCodeVerified = true;
                        _verificationCode = enteredCode; // Store the code for later use
                        pnlVerification.Visible = false;
                        pnlCreateAccount.Visible = true;

                        // For invited users, hide organization field
                        txtOrganizationName.Visible = false;
                        lblOrganizationName.Visible = false;
                        lblCreateAccountTitle.Text = "Create Your Account";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid invitation code. Please check and try again." + ex.Message, "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // For admin registration, check against generated code
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error verifying code: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modify BtnCreateAccount_Click to handle invited user flow
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

            if (!_isInvitedUser && string.IsNullOrWhiteSpace(txtOrganizationName.Text))
            {
                MessageBox.Show("Organization name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool success;
                string message;

                if (_isInvitedUser)
                {
                    // Complete invitation process
                    var result = await _authService.CompleteInvitationAsync(
                        _email,
                        _verificationCode,
                        txtPassword.Text);

                    success = result.success;
                    message = result.message;

                    if (success)
                    {
                        MessageBox.Show("Your account has been created successfully! You can now log in.",
                            "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Navigate to login form
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error creating account: {message}",
                            "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Admin registration process
                    await _orgService.CreateOrganizationAsync(txtOrganizationName.Text, _userId);

                    var result = await _authService.CompleteAdminRegistrationAsync(
                        _email,
                        _verificationCode,
                        txtPassword.Text,
                        txtOrganizationName.Text);

                    success = result.success;
                    message = result.message;

                    if (success)
                    {
                        MessageBox.Show("Admin account created successfully! You can now log in.",
                            "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Navigate to login form
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error creating account: {message}",
                            "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating account: {ex.Message}",
                    "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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