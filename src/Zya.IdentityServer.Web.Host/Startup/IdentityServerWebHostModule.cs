using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Zya.IdentityServer.Configuration;

namespace Zya.IdentityServer.Web.Host.Startup
{
    [DependsOn(
       typeof(IdentityServerWebCoreModule))]
    public class IdentityServerWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public IdentityServerWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServerWebHostModule).GetAssembly());
        }
        public override void PostInitialize()
        {
            base.PostInitialize();
        }
    }
}
