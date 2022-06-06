using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CrudOperations.EntityFrameworkCore;
using CrudOperations.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CrudOperations.Web.Tests
{
    [DependsOn(
        typeof(CrudOperationsWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class CrudOperationsWebTestModule : AbpModule
    {
        public CrudOperationsWebTestModule(CrudOperationsEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CrudOperationsWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(CrudOperationsWebMvcModule).Assembly);
        }
    }
}