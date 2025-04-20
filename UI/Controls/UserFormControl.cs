using System;
using System.Windows.Forms;
using ims.Models;
using ims.Services;
using ims.Utils;

namespace ims.UI.Controls
{
    public partial class UserFormControl : UserControl
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;
        private User _currentUser;
        private bool _isEditMode = false;
        private readonly string _organizationId;

        public event EventHandler UserSaved;
        public event EventHandler CancelRequested;

        public UserFormControl()
        {
            InitializeComponent();
            _userService = ServiceResolver.GetUserService();
            _authService = ServiceResolver.GetAuthService();

            // Initialize combobox with roles
            cmbRole.Items.Clear();
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                cmbRole.Items.Add(role.ToString());
            }

            // Default to Staff role
            cmbRole.SelectedItem = UserRole.Staff.ToString();

            _organizationId = CacheManager.CurrentOrganizationId;
        }

        public void SetupForNewUser()
        {
            _isEditMode = false;
            _currentUser = null;

            txtEmail.Enabled = true;
            txtEmail.Text = string.Empty;

            // Hide password fields for new user (they'll set it via invitation flow)
            lblPassword.Visible = false;
            txtPassword.Visible = false;

            btnSave.Text = "Invite User";

            // Set title
            lblTitle.Text = "Add New User";

            // Set available roles based on current user's role
            SetAvailableRoles();
        }

        public void SetupForEditUser(User user)
        {
            _isEditMode = true;
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));

            txtEmail.Text = user.Email;
            txtEmail.Enabled = false; // Don't allow email editing

            cmbRole.SelectedItem = user.Role.ToString();

            // Show password fields for edit mode
            lblPassword.Visible = true;
            txtPassword.Visible = true;
            txtPassword.Text = string.Empty; // Never show actual password

            btnSave.Text = "Update User";

            // Set title
            lblTitle.Text = "Edit User";

            // Set available roles based on permissions
            SetAvailableRoles();
        }

        private void SetAvailableRoles()
        {
            UserRole currentUserRole = CacheManager.CurrentUserRole;

            // Clear any previously disabled roles
            cmbRole.Enabled = true;

            // Iterate through the available roles in the dropdown
            foreach (var item in cmbRole.Items)
            {
                UserRole role = (UserRole)Enum.Parse(typeof(UserRole), item.ToString());

                // In edit mode: check if the current user can manage the target user
                if (_isEditMode && _currentUser != null)
                {
                    // If you can't manage the user at all, disable the role dropdown completely
                    if (!_userService.CanManageUser(currentUserRole, _currentUser.Role))
                    {
                        cmbRole.Enabled = false;
                        break;
                    }

                    // Check if the current user can change the role to this specific role
                    if (!_userService.CanChangeRole(currentUserRole, _currentUser.Role, role))
                    {
                        // Disable this option or handle as needed
                        // Unfortunately most ComboBox controls don't allow individual item disabling
                        // If this is a critical requirement, you might need a custom control

                        // For now, if we can't change to this role and it's currently selected,
                        // we won't let the user change it by disabling the dropdown
                        if (cmbRole.SelectedItem.ToString() == role.ToString())
                        {
                            cmbRole.Enabled = false;
                            break;
                        }
                    }
                }
                // In new user mode: check if current user can create users with this role
                else if (!_isEditMode)
                {
                    // Using a dedicated helper that checks if the current user can create a user with this role
                    if (!RoleUtils.CanPromoteToRole(currentUserRole, role))
                    {
                        // If this is the currently selected role and it's not allowed, select a valid role
                        if (cmbRole.SelectedItem.ToString() == role.ToString())
                        {
                            // Find a valid role to select instead
                            bool validRoleFound = false;
                            for (int i = 0; i < cmbRole.Items.Count; i++)
                            {
                                UserRole r = (UserRole)Enum.Parse(typeof(UserRole), cmbRole.Items[i].ToString());
                                if (RoleUtils.CanPromoteToRole(currentUserRole, r))
                                {
                                    cmbRole.SelectedIndex = i;
                                    validRoleFound = true;
                                    break;
                                }
                            }

                            // If no valid role found, disable the dropdown
                            if (!validRoleFound)
                            {
                                cmbRole.Enabled = false;
                                break;
                            }
                        }
                    }
                }
            }
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                if (_isEditMode)
                {
                    // Update existing user
                    if (_currentUser != null)
                    {
                        UserRole currentUserRole = CacheManager.CurrentUserRole;

                        // Verify user has permission to manage this user
                        if (!_userService.CanManageUser(currentUserRole, _currentUser.Role))
                        {
                            MessageBox.Show("You don't have permission to edit this user.",
                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Update role if changed
                        UserRole newRole = (UserRole)Enum.Parse(typeof(UserRole), cmbRole.SelectedItem.ToString());
                        if (_currentUser.Role != newRole)
                        {
                            if (!_userService.CanChangeRole(currentUserRole, _currentUser.Role, newRole))
                            {
                                MessageBox.Show("You don't have permission to change this user's role.",
                                    "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            _currentUser.Role = newRole;
                        }

                        // Update password if provided
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            // Validate password again before hashing
                            if (txtPassword.Text.Length < 8)
                            {
                                MessageBox.Show("Password must be at least 8 characters long.",
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            string passwordHash = _authService.HashPassword(txtPassword.Text);
                            _currentUser.PasswordHash = passwordHash;

                            // For security, clear the password field
                            txtPassword.Clear();
                        }

                        // Update the user
                        await _userService.UpdateUserByIdAsync(_currentUser.Id, _currentUser);
                        MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Create new user invitation
                    UserRole role = (UserRole)Enum.Parse(typeof(UserRole), cmbRole.SelectedItem.ToString());
                    UserRole currentUserRole = CacheManager.CurrentUserRole;

                    if (!RoleUtils.CanPromoteToRole(currentUserRole, role))
                    {
                        MessageBox.Show("You don't have permission to create a user with this role.",
                            "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var result = await _authService.InviteUserAsync(txtEmail.Text, role, _organizationId, CacheManager.CurrentUserId);
                    if (result.success)
                    {
                        MessageBox.Show($"Invitation sent to {txtEmail.Text}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to send invitation: {result.message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Notify parent control that user was saved
                UserSaved?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Consider logging the exception here
            }
        }
        private bool ValidateForm()
        {
            // Validate email
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate role is selected
            if (cmbRole.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a role for this user.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // If in edit mode and password field is shown
            if (_isEditMode && txtPassword.Visible && !string.IsNullOrEmpty(txtPassword.Text))
            {
                // Validate password strength
                if (txtPassword.Text.Length < 8)
                {
                    MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}