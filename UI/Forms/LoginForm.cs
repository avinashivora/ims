using System;
using System.Windows.Forms;
using ims.Models;
using ims.Services;
using ims.Utils;

namespace ims.UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        public event EventHandler LoginSuccessful;
        public event EventHandler RegisterRequested;
        public event EventHandler ResetPasswordRequested;
        public event EventHandler InvitedUserRequested;

        public LoginForm()
        {
            InitializeComponent();
            _authService = ServiceResolver.GetAuthService();
        }

        private void OnLoginSuccess(string orgId, string userId, UserRole userRole)
        {
            // Set the cache values
            CacheManager.SetSession(orgId, userId, userRole);

            // Raise the event to signal successful login
            LoginSuccessful?.Invoke(this, EventArgs.Empty);
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                // Disable login button to prevent double-submission
                btnLogin.Enabled = false;
                lblError.Visible = false;
                try
                {
                    string email = txtEmail.Text.Trim();
                    string password = txtPassword.Text;
                    var (success, user) = await _authService.AuthenticateAsync(email, password);
                    if (success)
                    {
                        // Get these values from your authentication process
                        string orgId = user.OrganizationId;
                        string userId = user.Id;
                        UserRole userRole = user.Role;

                        // Call the method to set cache and raise event
                        OnLoginSuccess(orgId, userId, userRole);
                        // Trigger successful login event
                        LoginSuccessful?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        lblError.Text = "User Doesn't Exist!";
                        lblError.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = $"An error occurred: {ex.Message}";
                    lblError.Visible = true;
                }
                finally
                {
                    btnLogin.Enabled = true;
                }
            }
        }

        private bool ValidateForm()
        {
            // Clear previous error
            lblError.Visible = false;
            // Validate email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblError.Text = "Please enter your email address.";
                lblError.Visible = true;
                return false;
            }
            // Basic email validation
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                lblError.Text = "Please enter a valid email address.";
                lblError.Visible = true;
                return false;
            }
            // Validate password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Please enter your password.";
                lblError.Visible = true;
                return false;
            }
            return true;
        }

        // Keep only the LinkLabel event handlers and remove the duplicate Click handlers
        private void LinkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open registration form
            RegisterRequested?.Invoke(this, EventArgs.Empty);
        }

        private void LinkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open reset password form
            ResetPasswordRequested?.Invoke(this, EventArgs.Empty);
        }

        private void InvitedUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InvitedUserRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}