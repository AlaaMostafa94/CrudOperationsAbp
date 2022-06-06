using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CrudOperations.Authorization;
using CrudOperations.Department.Dto;
using CrudOperations.Employee.Dto;

namespace CrudOperations
{
    [DependsOn(
        typeof(CrudOperationsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CrudOperationsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CrudOperationsAuthorizationProvider>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                config => config.CreateMap<CrudOperations.Employee.Employee, EmployeeDto>()
                .ForMember(u => u.Name, options => options.MapFrom(input => input.Name))
                .ForMember(u => u.Age, options => options.MapFrom(input => input.Age))
                .ForMember(u => u.Salary, options => options.MapFrom(input => input.Salary))
                .ForMember(e => e.Department, option => option.MapFrom(input => input.Department)).MaxDepth(1)
                );

            //Configuration.Modules.AbpAutoMapper().Configurators.Add(
            //    config=>config.CreateMap<CrudOperations.Employee.Employee,EmployeeDto>()
            //    .ForMember(u=>u.FullName,options=>options.MapFrom(input=>input.Name))
            //    );
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CrudOperationsApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
