using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ims.Models;

namespace ims.Services
{
    public class AuthService(UserService userService, EmailService emailService)
    {
        private readonly UserService _userService = userService;
        private readonly EmailService _emailService = emailService;

        public async Task<(bool success, User user)> AuthenticateAsync(string email, string password)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null) 
                return (false, user);

            return (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash), user);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 12); // 12 is work factor
        }

        public string GenerateCode()
        {
            // Generate a secure 6-digit code
            using var rng = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[4];
            rng.GetBytes(randomBytes);
            int randomNumber = Math.Abs(BitConverter.ToInt32(randomBytes, 0)) % 1000000;
            return randomNumber.ToString("D6");
        }

        public async Task<(bool success, string message)> RegisterAdminAsync(string email, string text)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));
            }

            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            // Check if user with this email already exists
            var existingUser = await _userService.GetUserByEmailAsync(email);
            if (existingUser != null)
            {
                return (false, "A user with this email already exists");
            }

            // Generate verification code
            string verificationCode = GenerateVerificationCode(); // Implement this to generate a 6-digit code

            // Create temporary user record
            var newUser = new User
            {
                Email = email,
                SignupCode = verificationCode,
                SignupCodeExpiry = DateTime.UtcNow.AddMinutes(15), // Code expires in 15 minutes
                FirstLogin = true,
                Role = UserRole.Admin // Default to Admin for initial registration
            };

            // Save the temporary user
            await _userService.AddUserAsync(newUser);

            // Send verification email with the code
            await _emailService.SendSignupCodeAsync(email, verificationCode);

            return (true, "Verification code sent to your email");
        }

        public async Task<(bool success, string message, string userId)> InitiateRegistrationAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));
            }

            // Check if user with this email already exists
            var existingUser = await _userService.GetUserByEmailAsync(email);
            if (existingUser != null)
            {
                return (false, "A user with this email already exists", null);
            }

            // Generate verification code
            string verificationCode = GenerateVerificationCode(); // Implement this to generate a 6-digit code

            // Create temporary user record
            var newUser = new User
            {
                Email = email,
                SignupCode = verificationCode,
                SignupCodeExpiry = DateTime.UtcNow.AddMinutes(15), // Code expires in 15 minutes
                FirstLogin = true,
                Role = UserRole.Admin // Default to Admin for initial registration
            };

            // Save the temporary user
            await _userService.AddUserAsync(newUser);
            var uid = newUser.Id;

            // Send verification email with the code
            //await _emailService.SendSignupCodeAsync(newUser.Email, newUser.SignupCode);

            return (true, "Verification code sent to your email", uid);
        }

        public async Task<(bool success, string message, User user)> CompleteAdminRegistrationAsync(
            string email, string code, string password, string organizationName)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));
            }

            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentException($"'{nameof(code)}' cannot be null or empty.", nameof(code));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty.", nameof(password));
            }

            if (string.IsNullOrEmpty(organizationName))
            {
                throw new ArgumentException($"'{nameof(organizationName)}' cannot be null or empty.", nameof(organizationName));
            }

            if (password.Length < 8)
            {
                throw new ArgumentException("Minimum Password Length of 8 characters");
            }

            var user = await _userService.GetUserByEmailAsync(email);

            if (user == null)
                return (false, "User not found", null);

            //if (user.SignupCode != code)
            //    return (false, "Invalid code", null);

            if (user.SignupCodeExpiry < DateTime.UtcNow)
            {
                await _userService.DeleteUserByIdAsync(user.Id);
                return (false, "Code expired. Please register again", null);
            }

            // Set password and complete signup
            user.PasswordHash = HashPassword(password);
            user.SignupCode = null;
            user.SignupCodeExpiry = null;
            user.FirstLogin = false;

            await _userService.UpdateUserByIdAsync(user.Id, user);

            return (true, "Registration completed", user);
        }

        public async Task<(bool success, string message)> InviteUserAsync(
            string email, UserRole role, string invitedBy, string organizationId)
        {
            // Verify inviter has permission to create this role
            var inviter = await _userService.GetUserByIdAsync(invitedBy);
            if (inviter == null)
                return (false, "Inviter not found");

            // Check role permissions
            if (!CanCreateRole(inviter.Role, role))
                return (false, "You don't have permission to create this role");

            // Check if email already exists
            var existingUser = await _userService.GetUserByEmailAsync(email);
            if (existingUser != null)
                return (false, "Email is already registered");

            var code = GenerateCode();
            var user = new User
            {
                Email = email,
                Role = role,
                OrganizationId = organizationId,
                CreatedBy = invitedBy,
                SignupCode = code,
                SignupCodeExpiry = DateTime.UtcNow.AddDays(1),
                FirstLogin = true
            };

            await _userService.AddUserAsync(user);
            await _emailService.SendInvitationAsync(email, code, inviter.Email);

            return (true, "Invitation sent successfully");
        }

        public async Task<(bool success, string message)> CompleteInvitationAsync(
            string email, string code, string password)
        {
            var user = await _userService.GetUserByEmailAsync(email);

            if (user == null)
                return (false, "User not found");

            if (user.SignupCode != code)
                return (false, "Invalid code");

            if (user.SignupCodeExpiry < DateTime.UtcNow)
            {
                await _userService.DeleteUserByIdAsync(user.Id);
                return (false, "Code expired. Please ask for a new invitation");
            }

            if (password.Length < 8)
            {
                throw new ArgumentException("Minimum Password Length of 8 characters");
            }


            // Set password and complete signup
            user.PasswordHash = HashPassword(password);
            user.SignupCode = null;
            user.SignupCodeExpiry = null;
            user.FirstLogin = false;

            await _userService.UpdateUserByIdAsync(user.Id, user);

            return (true, "Account setup completed");
        }

        public async Task<(bool success, string message)> InitiatePasswordResetAsync(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
                return (false, "Email not found");

            var code = GenerateCode();
            user.ResetPasswordCode = code;
            user.ResetPasswordCodeExpiry = DateTime.UtcNow.AddHours(1);

            await _userService.UpdateUserByIdAsync(user.Id, user);
            await _emailService.SendPasswordResetCodeAsync(email, code);

            return (true, "Password reset code sent to your email");
        }

        public async Task<(bool success, string message)> CompletePasswordResetAsync(string email, string code, string newPassword)
        {
            var user = await _userService.GetUserByEmailAsync(email);

            if (user == null)
                return (false, "User not found");

            if (user.ResetPasswordCode != code)
                return (false, "Invalid code");

            if (user.ResetPasswordCodeExpiry < DateTime.UtcNow)
                return (false, "Code expired. Please request a new password reset");

            if (newPassword.Length < 8)
            {
                throw new ArgumentException("Minimum Password Length of 8 characters");
            }


            // Set new password
            user.PasswordHash = HashPassword(newPassword);
            user.ResetPasswordCode = null;
            user.ResetPasswordCodeExpiry = null;

            await _userService.UpdateUserByIdAsync(user.Id, user);

            return (true, "Password reset successfully");
        }

        private bool CanCreateRole(UserRole creatorRole, UserRole targetRole)
        {
            // Admin can create any role
            if (creatorRole == UserRole.Admin)
                return true;

            // Manager can create Manager or Staff
            if (creatorRole == UserRole.Manager &&
                (targetRole == UserRole.Manager || targetRole == UserRole.Staff))
                return true;

            // Staff cannot create users
            return false;
        }

        // Add these methods to your AuthService.cs class

        /// <summary>
        /// Verifies a registration code against the stored code for a user
        /// </summary>
        /// <param name="email">The email address of the user</param>
        /// <param name="code">The verification code to check</param>
        /// <returns>True if the code is valid and not expired</returns>
        public async Task<bool> VerifyRegistrationCodeAsync(string email, string code)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
                return false;

            // Check if registration code matches and hasn't expired
            if (user.SignupCode == code &&
                user.SignupCodeExpiry > DateTime.UtcNow)
            {
                // Clear the code once used
                user.SignupCode = null;
                user.SignupCodeExpiry = null;
                await _userService.UpdateUserByIdAsync(user.Id, user);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifies a password reset code against the stored code for a user
        /// </summary>
        /// <param name="email">The email address of the user</param>
        /// <param name="code">The verification code to check</param>
        /// <returns>True if the code is valid and not expired</returns>
        public async Task<bool> VerifyPasswordResetCodeAsync(string email, string code)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
                return false;

            // Check if reset code matches and hasn't expired
            if (user.ResetPasswordCode == code &&
                user.ResetPasswordCodeExpiry > DateTime.UtcNow)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Resends the registration code to the user's email
        /// </summary>
        /// <param name="email">The email address to send the code to</param>
        public async Task ResendRegistrationCodeAsync(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email) ?? throw new Exception("User not found");

            // Generate a new 6-digit code
            string code = GenerateCode();

            // Set expiration to 24 hours from now
            user.SignupCode = code;
            user.SignupCodeExpiry = DateTime.UtcNow.AddHours(24);

            // Save the user
            await _userService.UpdateUserByIdAsync(user.Id, user);

            // Send email with the new code
            await _emailService.SendSignupCodeAsync(email, code);
        }

        /// <summary>
        /// Requests a password reset for the specified email
        /// </summary>
        /// <param name="email">The email address to send the reset code to</param>
        public async Task RequestPasswordResetAsync(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email) ?? throw new Exception("User not found");

            // Generate a new 6-digit code
            string code = GenerateCode();

            // Set expiration to 1 hour from now
            user.ResetPasswordCode = code;
            user.ResetPasswordCodeExpiry = DateTime.UtcNow.AddHours(1);

            // Save the user
            await _userService.UpdateUserByIdAsync(user.Id, user);

            // Send email with the reset code
            await _emailService.SendPasswordResetCodeAsync(email, code);
        }

        /// <summary>
        /// Generates a random 6-digit verification code
        /// </summary>
        /// <returns>A 6-digit string code</returns>
        private string GenerateVerificationCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}