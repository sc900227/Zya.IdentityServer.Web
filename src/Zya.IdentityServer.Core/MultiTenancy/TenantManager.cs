using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Zya.IdentityServer.Authorization.Users;
using Zya.IdentityServer.Editions;

namespace Zya.IdentityServer.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
