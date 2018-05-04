using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Zya.IdentityServer.MultiTenancy.Dto;

namespace Zya.IdentityServer.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
