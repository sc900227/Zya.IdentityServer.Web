using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Zya.IdentityServer.Configuration.Dto;

namespace Zya.IdentityServer.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : IdentityServerAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
