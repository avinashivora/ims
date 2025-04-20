using ims.Models;

namespace ims.Utils
{
    public static class RoleUtils
    {
        public static bool CanCreateUser(UserRole creatorRole, UserRole targetRole)
        {
            switch (creatorRole)
            {
                case UserRole.Admin:
                    // Admin can create any role
                    return true;
                case UserRole.Manager:
                    // Manager can create Manager or Staff only
                    return (targetRole == UserRole.Manager || targetRole == UserRole.Staff);
                default:
                    // Staff cannot create users
                    return false;
            }
        }

        public static bool CanDeleteUser(UserRole deleterRole, UserRole targetRole)
        {
            switch (deleterRole)
            {
                case UserRole.Admin:
                    // Admin can delete any role
                    return true;
                case UserRole.Manager:
                    // Manager can delete Staff only
                    return (targetRole == UserRole.Staff);
                default:
                    // Staff cannot delete users
                    return false;
            }
        }

        public static bool CanPromoteToRole(UserRole promoterRole, UserRole targetRole)
        {
            switch (promoterRole)
            {
                case UserRole.Admin:
                    // Admin can promote to any role
                    return true;
                case UserRole.Manager:
                    // Manager can promote to Manager or Staff only
                    return (targetRole == UserRole.Manager || targetRole == UserRole.Staff);
                default:
                    // Staff cannot promote users
                    return false;
            }
        }

        public static bool CanViewUser(UserRole viewerRole, UserRole targetRole)
        {
            switch (viewerRole)
            {
                case UserRole.Admin:
                    // Admin can view any role
                    return true;
                case UserRole.Manager:
                    // Manager can view Staff and Manager only
                    return (targetRole != UserRole.Admin);
                default:
                    // Staff cannot view user management
                    return false;
            }
        }

        public static bool CanViewOldBillings(UserRole role)
        {
            // Only Admin and Manager can view old billings
            return (role == UserRole.Admin || role == UserRole.Manager);
        }
    }
}