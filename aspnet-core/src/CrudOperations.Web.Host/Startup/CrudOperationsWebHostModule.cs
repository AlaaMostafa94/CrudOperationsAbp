using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CrudOperations.Configuration;

namespace CrudOperations.Web.Host.Startup
{
    [DependsOn(
       typeof(CrudOperationsWebCoreModule))]
    public class CrudOperationsWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CrudOperationsWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CrudOperationsWebHostModule).GetAssembly());
        }
    }
}
