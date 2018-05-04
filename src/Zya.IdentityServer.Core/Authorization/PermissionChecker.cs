using Abp.Authorization;
using Zya.IdentityServer.Authorization.Roles;
using Zya.IdentityServer.Authorization.Users;

namespace Zya.IdentityServer.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
