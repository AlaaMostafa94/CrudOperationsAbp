using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CrudOperations.Controllers
{
    public abstract class CrudOperationsControllerBase: AbpController
    {
        protected CrudOperationsControllerBase()
        {
            LocalizationSourceName = CrudOperationsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
