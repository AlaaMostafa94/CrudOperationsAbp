using System.Threading.Tasks;
using Abp.Application.Services;
using CrudOperations.Sessions.Dto;

namespace CrudOperations.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
