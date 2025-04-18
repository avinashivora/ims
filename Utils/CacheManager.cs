namespace ims.Utils
{
    public static class CacheManager
    {
        public static string CurrentOrganizationId { get; private set; }
        public static string CurrentUserId { get; private set; }
        public static string CurrentUserRole { get; private set; }

        public static void SetSession(string orgId, string userId, string userRole)
        {
            CurrentOrganizationId = orgId;
            CurrentUserId = userId;
            CurrentUserRole = userRole;
        }

        public static void ClearSession()
        {
            CurrentOrganizationId = null;
            CurrentUserId = null;
            CurrentUserRole = null;
        }

        public static bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUserId);
    }
}
