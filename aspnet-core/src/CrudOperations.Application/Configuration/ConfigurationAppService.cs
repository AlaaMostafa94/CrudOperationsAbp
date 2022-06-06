using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CrudOperations.Configuration.Dto;

namespace CrudOperations.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CrudOperationsAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
