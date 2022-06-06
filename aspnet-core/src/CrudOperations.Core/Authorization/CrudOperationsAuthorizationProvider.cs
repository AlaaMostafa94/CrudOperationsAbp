using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace CrudOperations.Authorization
{
    public class CrudOperationsAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            context.CreatePermission(PermissionNames.AddEmployees);
            context.CreatePermission(PermissionNames.NewPermission, L("New Permission"));
            context.CreatePermission(PermissionNames.TestPermission);
            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CrudOperationsConsts.LocalizationSourceName);
        }
    }
}
