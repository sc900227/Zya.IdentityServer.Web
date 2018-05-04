using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Zya.IdentityServer.Authorization;

namespace Zya.IdentityServer
{
    [DependsOn(
        typeof(IdentityServerCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class IdentityServerApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<IdentityServerAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IdentityServerApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
