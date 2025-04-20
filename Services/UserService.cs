using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ims.Models;
using ims.Utils;
using MongoDB.Driver;

namespace ims.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;
        private readonly EmailService _emailService;
        private AuthService _authService;

        public UserService(EmailService emailService)
        {
            var client = new MongoClient(Constants.MongoConnectionString);
            var db = client.GetDatabase(Constants.DatabaseName);
            _userCollection = db.GetCollection<User>(Constants.UserCollection);
            _emailService = emailService;
        }

        // To avoid circular dependency
        public void SetAuthService(AuthService authService)
        {
            _authService = authService;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userCollection.Find(u => u.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public async Task UpdateUserByIdAsync(string id, User updated)
        {
            await _userCollection.ReplaceOneAsync(u => u.Id == id, updated);
        }

        public async Task UpdateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(user.Id))
                throw new ArgumentException("User ID cannot be null or empty", nameof(user));

            await _userCollection.ReplaceOneAsync(u => u.Id == user.Id, user);
        }

        public async Task DeleteUserByIdAsync(string id)
        {
            await _userCollection.DeleteOneAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetUsersByOrganizationIdAsync(string orgId)
        {
            return await _userCollection.Find(u => u.OrganizationId == orgId).ToListAsync();
        }

        public async Task<List<User>> GetManageableUsersByOrgAndRoleAsync(string orgId, UserRole managerRole)
        {
            if (managerRole == UserRole.Admin)
            {
                // Admins can see all users
                return await _userCollection.Find(u => u.OrganizationId == orgId).ToListAsync();
            }
            else if (managerRole == UserRole.Manager)
            {
                // Managers can only see non-admin users
                return await _userCollection.Find(u =>
                    u.OrganizationId == orgId &&
                    u.Role != UserRole.Admin).ToListAsync();
            }

            // Staff can't manage users
            return [];
        }

        public async Task<(bool success, string message)> RequestAccountDeletionAsync(string userId, string requestedByUserId)
        {
            var user = await GetUserByIdAsync(userId);
            var requestor = await GetUserByIdAsync(requestedByUserId);

            if (user == null || requestor == null)
                return (false, "User not found");

            // Check if it's self-deletion for an Admin
            if (userId == requestedByUserId && user.Role == UserRole.Admin)
            {
                var code = _authService.GenerateCode();
                user.DeleteConfirmationCode = code;
                user.DeleteConfirmationCodeExpiry = DateTime.UtcNow.AddHours(1);

                await UpdateUserByIdAsync(userId, user);
                await _emailService.SendDeleteConfirmationCodeAsync(user.Email, code, false);

                return (true, "Confirmation code sent to your email");
            }

            // Check if requestor has permission to delete this user
            if (!CanManageUser(requestor.Role, user.Role))
                return (false, "You don't have permission to delete this user");

            // For immediate deletion by another user
            await DeleteUserByIdAsync(userId);
            await _emailService.SendAccountDeletionNotificationAsync(user.Email);

            return (true, "User deleted successfully");
        }

        public async Task<(bool success, string message)> ConfirmAccountDeletionAsync(string userId, string code)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null)
                return (false, "User not found");

            if (user.DeleteConfirmationCode != code)
                return (false, "Invalid confirmation code");

            if (user.DeleteConfirmationCodeExpiry < DateTime.UtcNow)
                return (false, "Confirmation code expired");

            await DeleteUserByIdAsync(userId);
            await _emailService.SendAccountDeletionNotificationAsync(user.Email);

            return (true, "Account deleted successfully");
        }

        public async Task<(bool success, string message)> ChangeUserRoleAsync(
            string targetUserId, UserRole newRole, string changedByUserId)
        {
            var targetUser = await GetUserByIdAsync(targetUserId);
            var changer = await GetUserByIdAsync(changedByUserId);

            if (targetUser == null || changer == null)
                return (false, "User not found");

            // Check if the changer has permission to change this role
            if (!CanChangeRole(changer.Role, targetUser.Role, newRole))
                return (false, "You don't have permission to change to this role");

            targetUser.Role = newRole;
            await UpdateUserByIdAsync(targetUserId, targetUser);

            return (true, "User role updated successfully");
        }

        public async Task CleanupExpiredUsersAsync()
        {
            var expiredUsers = await _userCollection.Find(u =>
                u.FirstLogin == true &&
                u.SignupCodeExpiry < DateTime.UtcNow).ToListAsync();

            foreach (var user in expiredUsers)
            {
                await DeleteUserByIdAsync(user.Id);
            }
        }

        // Made these public since they're core business logic that UI needs to respect
        public bool CanManageUser(UserRole managerRole, UserRole targetRole)
        {
            // Admin can manage any role
            if (managerRole == UserRole.Admin)
                return true;

            // Manager can manage Staff or Managers but not Admins
            if (managerRole == UserRole.Manager && targetRole != UserRole.Admin)
                return true;

            // Staff can't manage users
            return false;
        }

        public bool CanChangeRole(UserRole changerRole, UserRole currentRole, UserRole newRole)
        {
            // Admin can change to any role
            if (changerRole == UserRole.Admin)
                return true;

            // Manager can only change between Manager and Staff
            if (changerRole == UserRole.Manager)
            {
                return (currentRole != UserRole.Admin && newRole != UserRole.Admin);
            }

            // Staff can't change roles
            return false;
        }

        // Add these methods to your UserService.cs class

        /// <summary>
        /// Sends an account deletion verification code to the user's email
        /// </summary>
        /// <param name="email">The email address of the user</param>
        public async Task SendAccountDeletionCodeAsync(string email)
        {
            var user = await GetUserByEmailAsync(email) ?? throw new Exception("User not found");

            // Generate a new 6-digit code using RNGCryptoServiceProvider for better security
            string code = GenerateSecureCode();

            // Set expiration to 1 hour from now
            user.DeleteConfirmationCode = code;
            user.DeleteConfirmationCodeExpiry = DateTime.UtcNow.AddHours(1);

            // Save the user
            await UpdateUserByIdAsync(user.Id, user);

            // Send email with the deletion code
            await _emailService.SendAccountDeletionNotificationAsync(email);
        }

        /// <summary>
        /// Verifies an account deletion code against the stored code for a user
        /// </summary>
        /// <param name="email">The email address of the user</param>
        /// <param name="code">The verification code to check</param>
        /// <returns>True if the code is valid and not expired</returns>
        public async Task<bool> VerifyAccountDeletionCodeAsync(string email, string code)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null)
                return false;

            // Check if deletion code matches and hasn't expired
            if (user.DeleteConfirmationCode == code && user.DeleteConfirmationCodeExpiry > DateTime.UtcNow)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Generates a cryptographically secure 6-digit code
        /// </summary>
        /// <returns>A 6-digit string code</returns>
        private string GenerateSecureCode()
        {
            using var provider = new System.Security.Cryptography.RNGCryptoServiceProvider();
            byte[] bytes = new byte[4];
            provider.GetBytes(bytes);

            // Convert to integer and ensure it's 6 digits
            int value = BitConverter.ToInt32(bytes, 0);
            value = Math.Abs(value % 900000) + 100000; // Ensures 6 digits

            return value.ToString();
        }
    }
}