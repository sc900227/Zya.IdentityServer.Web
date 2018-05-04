using System.Threading.Tasks;
using Abp.Application.Services;
using Zya.IdentityServer.Authorization.Accounts.Dto;

namespace Zya.IdentityServer.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
