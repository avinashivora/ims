using System;
using System.Windows.Forms;
using ims.Services;
using ims.Utils;

namespace ims.UI.Forms
{
    public partial class CodeVerificationForm : Form
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;
        private readonly string _email;
        private readonly VerificationType _verificationType;

        // Store the action to perform after successful verification
        private Action<string> _onVerificationSuccess;

        public enum VerificationType
        {
            Registration,
            PasswordReset,
            DeleteAccount,
            DeleteOrganization,
            InvitedUser
        }

        public CodeVerificationForm(string email, VerificationType verificationType)
        {
            InitializeComponent();

            _authService = ServiceResolver.GetAuthService();
            _userService = ServiceResolver.GetUserService();
            _email = email;
            _verificationType = verificationType;

            // Set the form title based on verification type
            SetFormTitle();
        }

        private void SetFormTitle()
        {
            switch (_verificationType)
            {
                case VerificationType.Registration:
                    lblTitle.Text = "Complete Registration";
                    lblInstructions.Text = $"Please enter the 6-digit code sent to {_email} to complete your registration.";
                    break;
                case VerificationType.PasswordReset:
                    lblTitle.Text = "Reset Password";
                    lblInstructions.Text = $"Please enter the 6-digit code sent to {_email} to reset your password.";
                    break;
                case VerificationType.DeleteAccount:
                    lblTitle.Text = "Delete Account";
                    lblInstructions.Text = $"Please enter the 6-digit code sent to {_email} to confirm account deletion.";
                    break;
                case VerificationType.DeleteOrganization:
                    lblTitle.Text = "Delete Organization";
                    lblInstructions.Text = $"Please enter the 6-digit code sent to {_email} to confirm organization deletion.";
                    break;
                case VerificationType.InvitedUser:
                    lblTitle.Text = "Accept Invitation";
                    lblInstructions.Text = $"Please enter the 6-digit code sent to {_email} to accept the invitation.";
                    break;
            }
        }

        public void SetSuccessAction(Action<string> onSuccess)
        {
            _onVerificationSuccess = onSuccess;
        }

        private async void BtnVerify_Click(object sender, EventArgs e)
        {
            string code = txtVerificationCode.Text.Trim();

            if (string.IsNullOrEmpty(code) || code.Length != 6)
            {
                MessageBox.Show("Please enter a valid 6-digit code.", "Invalid Code",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isValid = false;

            try
            {
                switch (_verificationType)
                {
                    case VerificationType.Registration:
                        isValid = await _authService.VerifyRegistrationCodeAsync(_email, code);
                        break;
                    case VerificationType.PasswordReset:
                        isValid = await _authService.VerifyPasswordResetCodeAsync(_email, code);
                        break;
                    case VerificationType.DeleteAccount:
                        isValid = await _userService.VerifyAccountDeletionCodeAsync(_email, code);
                        break;
                    case VerificationType.DeleteOrganization:
                        var orgService = ServiceResolver.GetOrganizationService();
                        isValid = await orgService.VerifyOrganizationDeletionCodeAsync(_email, code);
                        break;
                }

                if (isValid)
                {
                    _onVerificationSuccess?.Invoke(code);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid or expired verification code. Please try again or request a new code.",
                        "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnResendCode_Click(object sender, EventArgs e)
        {
            bool send = false;
            try
            {
                switch (_verificationType)
                {
                    case VerificationType.Registration:
                        _ = _authService.ResendRegistrationCodeAsync(_email);
                        send = true;
                        break;
                    case VerificationType.PasswordReset:
                        _ = _authService.RequestPasswordResetAsync(_email);
                        send = true;
                        break;
                    case VerificationType.DeleteAccount:
                        _ = _userService.SendAccountDeletionCodeAsync(_email);
                        send = true;
                        break;
                    case VerificationType.DeleteOrganization:
                        var orgService = ServiceResolver.GetOrganizationService();
                        _ = orgService.SendOrganizationDeletionCodeAsync(_email);
                        send = true;
                        break;
                    case VerificationType.InvitedUser:
                        send = false;
                        break;
                }
                if (!send)
                {
                    MessageBox.Show("Failed to send the code.", "Ask for the invite code again from the organization management.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show($"A new verification code has been sent to {_email}.", "Code Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to resend code: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}