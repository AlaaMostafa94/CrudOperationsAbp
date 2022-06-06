using Abp.Authorization;
using CrudOperations.Authorization.Roles;
using CrudOperations.Authorization.Users;

namespace CrudOperations.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
