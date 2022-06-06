using Abp.Application.Services;
using CrudOperations.MultiTenancy.Dto;

namespace CrudOperations.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

