using System.Threading.Tasks;
using Abp.Application.Services;
using Zya.IdentityServer.Sessions.Dto;

namespace Zya.IdentityServer.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
