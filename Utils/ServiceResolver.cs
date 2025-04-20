using ims.Services;

namespace ims.Utils
{
    public static class ServiceResolver
    {
        private static readonly EmailService _emailService;
        private static readonly UserService _userService;
        private static readonly AuthService _authService;
        private static readonly OrganizationService _organizationService;

        static ServiceResolver()
        {
            // Create services in the correct order to resolve circular dependencies
            _emailService = new EmailService();
            _userService = new UserService(_emailService);
            _authService = new AuthService(_userService, _emailService);
            _organizationService = new OrganizationService(_userService, _emailService, _authService);

            // Now set the auth service in the user service
            _userService.SetAuthService(_authService);
        }

        public static EmailService GetEmailService() => _emailService;
        public static UserService GetUserService() => _userService;
        public static AuthService GetAuthService() => _authService;
        public static OrganizationService GetOrganizationService() => _organizationService;
    }
}