using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ims.Models;
using ims.Utils;
using MongoDB.Driver;

namespace ims.Services
{
    public class OrganizationService
    {
        private readonly IMongoCollection<Organization> _organizationCollection;
        private readonly UserService _userService;
        private readonly EmailService _emailService;
        private readonly AuthService _authService;

        public OrganizationService(UserService userService, EmailService emailService, AuthService authService)
        {
            var client = new MongoClient(Constants.MongoConnectionString);
            var db = client.GetDatabase(Constants.DatabaseName);
            _organizationCollection = db.GetCollection<Organization>(Constants.OrganizationCollection);
            _userService = userService;
            _emailService = emailService;
            _authService = authService;
        }

        public async Task<List<Organization>> GetAllOrganizationsAsync()
        {
            return await _organizationCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Organization> GetOrganizationByIdAsync(string id)
        {
            return await _organizationCollection.Find(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Organization> CreateOrganizationAsync(string name, string createdByUserId)
        {
            var organization = new Organization
            {
                Name = name,
                CreatedByUserId = createdByUserId,
                CreatedAt = DateTime.UtcNow
            };

            await _organizationCollection.InsertOneAsync(organization);

            // Update the creating user's organization ID
            var user = await _userService.GetUserByIdAsync(createdByUserId);
            if (user != null)
            {
                user.OrganizationId = organization.Id;
                await _userService.UpdateUserByIdAsync(createdByUserId, user);
            }

            return organization;
        }

        public async Task UpdateOrganizationAsync(string id, Organization updated)
        {
            await _organizationCollection.ReplaceOneAsync(o => o.Id == id, updated);
        }

        public async Task<(bool success, string message)> RequestOrganizationDeletionAsync(string organizationId, string userId)
        {
            // Verify user is an admin
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null || user.Role != UserRole.Admin || user.OrganizationId != organizationId)
                return (false, "You don't have permission to delete this organization");

            var organization = await GetOrganizationByIdAsync(organizationId);
            if (organization == null)
                return (false, "Organization not found");

            // Generate confirmation code
            var code = _authService.GenerateCode();
            user.DeleteConfirmationCode = code;
            user.DeleteConfirmationCodeExpiry = DateTime.UtcNow.AddHours(1);

            await _userService.UpdateUserByIdAsync(userId, user);
            await _emailService.SendDeleteConfirmationCodeAsync(user.Email, code, true);

            return (true, "Confirmation code sent to your email");
        }

        public async Task<(bool success, string message)> ConfirmOrganizationDeletionAsync(
            string organizationId, string userId, string code)
        {
            // Verify user is an admin
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null || user.Role != UserRole.Admin || user.OrganizationId != organizationId)
                return (false, "You don't have permission to delete this organization");

            if (user.DeleteConfirmationCode != code)
                return (false, "Invalid confirmation code");

            if (user.DeleteConfirmationCodeExpiry < DateTime.UtcNow)
                return (false, "Confirmation code expired");

            // Delete organization and all related entities
            var organization = await GetOrganizationByIdAsync(organizationId);
            if (organization == null)
                return (false, "Organization not found");

            // 1. Get all users in the organization
            var orgUsers = await _userService.GetUsersByOrganizationIdAsync(organizationId);

            // 2. Send deletion notifications
            foreach (var orgUser in orgUsers)
            {
                await _emailService.SendAccountDeletionNotificationAsync(orgUser.Email);
            }

            // 3. Delete all users
            foreach (var orgUser in orgUsers)
            {
                await _userService.DeleteUserByIdAsync(orgUser.Id);
            }

            // 4. Delete organization
            await _organizationCollection.DeleteOneAsync(o => o.Id == organizationId);

            // TODO: Delete categories, items, and bills (implementation not shown)

            return (true, "Organization and all related data deleted successfully");
        }

        // Add these methods to your OrganizationService.cs class

        /// <summary>
        /// Sends an organization deletion verification code to the admin's email
        /// </summary>
        /// <param name="adminEmail">The email address of the organization admin</param>
        public async Task SendOrganizationDeletionCodeAsync(string adminEmail)
        {
            var user = await _userService.GetUserByEmailAsync(adminEmail) ?? throw new Exception("User not found");

            // Ensure the user is an admin
            if (user.Role == UserRole.Admin)
            {
                // Get the organization
                _ = await GetOrganizationByIdAsync(user.OrganizationId) ?? throw new Exception("Organization not found");

                // Generate a new 6-digit code
                string code = GenerateSecureCode();

                // Set expiration to 1 hour from now
                user.DeleteConfirmationCode = code;
                user.DeleteConfirmationCodeExpiry = DateTime.UtcNow.AddHours(1);

                // Save the user
                await _userService.UpdateUserByIdAsync(user.Id, user);

                // Send email with the deletion code
                await _emailService.SendDeleteConfirmationCodeAsync(adminEmail, code, true);
            }
            else
                throw new Exception("Only administrators can delete organizations");
        }

        /// <summary>
        /// Verifies an organization deletion code against the stored code
        /// </summary>
        /// <param name="adminEmail">The email address of the admin</param>
        /// <param name="code">The verification code to check</param>
        /// <returns>True if the code is valid and not expired</returns>
        public async Task<bool> VerifyOrganizationDeletionCodeAsync(string adminEmail, string code)
        {
            var user = await _userService.GetUserByEmailAsync(adminEmail);
            if (user == null)
                return false;

            // Verify user is an admin
            if (user.Role != UserRole.Admin)
                return false;

            // Get the organization
            var organization = await GetOrganizationByIdAsync(user.OrganizationId);
            if (organization == null)
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