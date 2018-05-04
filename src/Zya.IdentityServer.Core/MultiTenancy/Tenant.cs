using Abp.MultiTenancy;
using Zya.IdentityServer.Authorization.Users;

namespace Zya.IdentityServer.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
