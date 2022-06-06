using System.Threading.Tasks;
using CrudOperations.Configuration.Dto;

namespace CrudOperations.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
