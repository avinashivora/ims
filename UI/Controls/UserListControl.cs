using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ims.Models;
using ims.Services;
using ims.Utils;

namespace ims.UI.Controls
{
    public partial class UserListControl : UserControl
    {
        private readonly UserService _userService;
        private List<User> _users;
        private readonly UserRole _currentUserRole;
        private readonly string _organizationId;

        public event EventHandler<string> UserSelected;
        public event EventHandler<string> UserEditRequested;
        public event EventHandler<string> UserDeleteRequested;
        public event EventHandler UserRefreshRequested;

        public UserListControl()
        {
            InitializeComponent();
            _userService = ServiceResolver.GetUserService();
            _currentUserRole = CacheManager.CurrentUserRole;
            _organizationId = CacheManager.CurrentOrganizationId;
            this.Load += UserListControl_Load;
        }

        private async void UserListControl_Load(object sender, EventArgs e)
        {
            await RefreshUserListAsync();
        }

        public async System.Threading.Tasks.Task RefreshUserListAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(_organizationId))
                {
                    MessageBox.Show("Organization ID not found in session.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _users = await _userService.GetManageableUsersByOrgAndRoleAsync(_organizationId, _currentUserRole);

                BindUsersToDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindUsersToDataGrid()
        {
            dgvUsers.Rows.Clear();

            foreach (var user in _users)
            {
                int rowIndex = dgvUsers.Rows.Add(
                    user.Id,
                    user.Email,
                    user.Role.ToString(),
                    user.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                    user.FirstLogin ? "Pending" : "Active"
                );

                // Add buttons in the actions column
                var editBtn = new Guna2Button
                {
                    Text = "Edit",
                    Size = new Size(60, 25),
                    BorderRadius = 5,
                    FillColor = Color.FromArgb(94, 148, 255),
                    Tag = user.Id
                };
                editBtn.Click += EditButton_Click;

                var deleteBtn = new Guna2Button
                {
                    Text = "Delete",
                    Size = new Size(60, 25),
                    BorderRadius = 5,
                    FillColor = Color.FromArgb(255, 82, 82),
                    Tag = user.Id
                };
                deleteBtn.Click += DeleteButton_Click;

                // Only enable edit/delete if current user has permission
                bool canManage = RoleUtils.CanDeleteUser(_currentUserRole, user.Role);
                deleteBtn.Enabled = canManage;
                editBtn.Enabled = RoleUtils.CanViewUser(_currentUserRole, user.Role);

                var actionCell = dgvUsers.Rows[rowIndex].Cells["Actions"];
                actionCell.Value = "Actions";

                // Store reference to buttons for easy access
                dgvUsers.Rows[rowIndex].Tag = new[] { editBtn, deleteBtn };
            }
        }

        private void DgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string userId = dgvUsers.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                UserSelected?.Invoke(this, userId);
            }
        }

        private void DgvUsers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Custom painting for the Actions column
            if (e.ColumnIndex >= 0 && dgvUsers.Columns[e.ColumnIndex].Name == "Actions" && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Get the buttons from row tag
                if (dgvUsers.Rows[e.RowIndex].Tag is Guna2Button[] buttons)
                {
                    // Calculate positions to place buttons side by side
                    int x = e.CellBounds.X + (e.CellBounds.Width - (buttons[0].Width + buttons[1].Width + 5)) / 2;
                    int y = e.CellBounds.Y + (e.CellBounds.Height - buttons[0].Height) / 2;

                    // Position the Edit button
                    buttons[0].Location = new Point(x, y);
                    buttons[0].Parent = dgvUsers;
                    buttons[0].BringToFront();
                    buttons[0].Visible = true;

                    // Position the Delete button
                    buttons[1].Location = new Point(x + buttons[0].Width + 5, y);
                    buttons[1].Parent = dgvUsers;
                    buttons[1].BringToFront();
                    buttons[1].Visible = true;
                }

                e.Handled = true;
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn && btn.Tag is string userId)
            {
                UserEditRequested?.Invoke(this, userId);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn && btn.Tag is string userId)
            {
                UserDeleteRequested?.Invoke(this, userId);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            UserRefreshRequested?.Invoke(this, EventArgs.Empty);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                BindUsersToDataGrid();
                return;
            }

            var filteredUsers = _users.Where(u =>
                u.Email.ToLower().Contains(searchTerm) ||
                u.Role.ToString().ToLower().Contains(searchTerm)).ToList();

            dgvUsers.Rows.Clear();

            foreach (var user in filteredUsers)
            {
                int rowIndex = dgvUsers.Rows.Add(
                    user.Id,
                    user.Email,
                    user.Role.ToString(),
                    user.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                    user.FirstLogin ? "Pending" : "Active"
                );

                // Add buttons as before...
                var editBtn = new Guna2Button
                {
                    Text = "Edit",
                    Size = new Size(60, 25),
                    BorderRadius = 5,
                    FillColor = Color.FromArgb(94, 148, 255),
                    Tag = user.Id
                };
                editBtn.Click += EditButton_Click;

                var deleteBtn = new Guna2Button
                {
                    Text = "Delete",
                    Size = new Size(60, 25),
                    BorderRadius = 5,
                    FillColor = Color.FromArgb(255, 82, 82),
                    Tag = user.Id
                };
                deleteBtn.Click += DeleteButton_Click;

                bool canManage = RoleUtils.CanDeleteUser(_currentUserRole, user.Role);
                deleteBtn.Enabled = canManage;
                editBtn.Enabled = RoleUtils.CanViewUser(_currentUserRole, user.Role);

                var actionCell = dgvUsers.Rows[rowIndex].Cells["Actions"];
                actionCell.Value = "Actions";

                dgvUsers.Rows[rowIndex].Tag = new[] { editBtn, deleteBtn };
            }
        }
    }
}