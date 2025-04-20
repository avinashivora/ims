using ims.Models;

namespace ims.Utils
{
    public static class CacheManager
    {
        public static string CurrentOrganizationId { get; private set; }
        public static string CurrentUserId { get; private set; }
        public static UserRole CurrentUserRole { get; private set; }
        public static string BillSavePath { get; set; }

        public static void SetSession(string orgId, string userId, UserRole userRole)
        {
            CurrentOrganizationId = orgId;
            CurrentUserId = userId;
            CurrentUserRole = userRole;
        }

        public static void ClearSession()
        {
            CurrentOrganizationId = null;
            CurrentUserId = null;
            CurrentUserRole = UserRole.LoggedOut;
            BillSavePath = null;
        }

        public static bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUserId);
    }
}
