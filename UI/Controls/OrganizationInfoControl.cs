using System;
using System.Windows.Forms;
using ims.Models;
using ims.Services;
using ims.UI.Forms;
using ims.Utils;

namespace ims.UI.Controls
{
    public partial class OrganizationInfoControl : UserControl
    {
        private readonly OrganizationService _organizationService;
        private readonly UserService _userService;
        private Organization _organization;
        private readonly string _organizationId;
        private readonly string _userID;
        private readonly UserRole _userRole;

        public event EventHandler DeleteRequested;

        public OrganizationInfoControl()
        {
            InitializeComponent();
            _organizationService = ServiceResolver.GetOrganizationService();
            _organizationId = CacheManager.CurrentOrganizationId;
            _userService = ServiceResolver.GetUserService();
            _userID = CacheManager.CurrentUserId;
            _userRole = CacheManager.CurrentUserRole;

            // Only admins can delete an organization
            btnDelete.Visible = _userRole == UserRole.Admin;

            LoadOrganizationData();
        }

        public async void LoadOrganizationData()
        {
            try
            {
                _organization = await _organizationService.GetOrganizationByIdAsync(_organizationId);

                if (_organization != null)
                {
                    lblOrgName.Text = _organization.Name;
                    lblCreatedAt.Text = $"Created: {_organization.CreatedAt:MMM dd, yyyy}";
                }
                else
                {
                    MessageBox.Show("Unable to load organization information.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading organization data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_userRole != UserRole.Admin)
            {
                MessageBox.Show("Only administrators can delete organizations.",
                    "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                "WARNING: This will permanently delete the organization and all associated data including users, inventory, and bills. This action cannot be undone.\n\nAre you sure you want to delete this organization?",
                "Confirm Organization Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // Request organization deletion - this sends a confirmation code
                    var result = await _organizationService.RequestOrganizationDeletionAsync(_organizationId, _userID);
                    if (result.success)
                    {
                        // Get the admin's email for verification
                        User user = await _userService.GetUserByEmailAsync(_userID);

                        using var verificationForm = new CodeVerificationForm(user.Email,
                            CodeVerificationForm.VerificationType.DeleteOrganization);

                        string verificationCode = "";
                        verificationForm.SetSuccessAction(code => verificationCode = code);

                        if (verificationForm.ShowDialog() == DialogResult.OK)
                        {
                            // Confirm organization deletion with the code
                            var (success, message) = await _organizationService.ConfirmOrganizationDeletionAsync(
                                _organizationId, _userID, verificationCode);

                            if (success)
                            {
                                MessageBox.Show("Organization deleted successfully. The application will now log out.",
                                    "Organization Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Notify parent about deletion
                                DeleteRequested?.Invoke(this, EventArgs.Empty);
                            }
                            else
                            {
                                MessageBox.Show($"Failed to delete organization: {message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Failed to initiate organization deletion: {result.message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}