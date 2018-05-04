using System.Threading.Tasks;
using Zya.IdentityServer.Configuration.Dto;

namespace Zya.IdentityServer.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
