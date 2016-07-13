using Abp.Authorization;
using Zdr.Authorization.Roles;
using Zdr.MultiTenancy;
using Zdr.Users;

namespace Zdr.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
