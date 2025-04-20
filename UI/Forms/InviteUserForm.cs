using System;
using System.Windows.Forms;
using ims.Models;
using ims.Services;
using ims.Utils;

namespace ims.UI.Forms
{
    public partial class InviteUserForm : Form
    {
        private readonly UserService _userService;
        private readonly EmailService _emailService;
        private readonly AuthService _authService;

        public InviteUserForm()
        {
            InitializeComponent();
            _userService = ServiceResolver.GetUserService();
            _emailService = ServiceResolver.GetEmailService();
            _authService = ServiceResolver.GetAuthService();

            // Load roles into dropdown
            InitializeRoleDropdown();
        }

        private void InitializeRoleDropdown()
        {
            // Clear existing items
            cmbRole.Items.Clear();

            // Get current user role from cache
            UserRole currentUserRole = CacheManager.CurrentUserRole;

            // Add roles based on current user's permissions
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                // Only add roles that the current user can assign
                if (RoleUtils.CanPromoteToRole(currentUserRole, role))
                {
                    cmbRole.Items.Add(role);
                }
            }

            // Select first role by default if any exists
            if (cmbRole.Items.Count > 0)
            {
                cmbRole.SelectedIndex = 0;
            }
        }

        private async void BtnInviteUser_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            // Validate email
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter a valid email address", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate role selection
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role for the user", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserRole selectedRole = (UserRole)cmbRole.SelectedItem;

            try
            {
                // Check if email already exists
                if (await _userService.GetUserByEmailAsync(email) != null)
                {
                    MessageBox.Show("A user with this email already exists", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get organization ID from cache
                string organizationId = CacheManager.CurrentOrganizationId;

                // Generate verification code
                string verificationCode = _authService.GenerateCode();

                // Create the user with pending status
                User newUser = new()
                {
                    Email = email,
                    Role = selectedRole,
                    OrganizationId = organizationId,
                    Status = "Pending",
                    SignupCode = verificationCode,
                    SignupCodeExpiry = DateTime.UtcNow.AddDays(1), // Expires in 1 day
                    CreatedAt = DateTime.UtcNow
                };

                await _userService.AddUserAsync(newUser);

                // Send invitation email
                await _emailService.SendInvitationAsync(email, verificationCode, selectedRole.ToString());

                MessageBox.Show($"Invitation sent to {email}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inviting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}