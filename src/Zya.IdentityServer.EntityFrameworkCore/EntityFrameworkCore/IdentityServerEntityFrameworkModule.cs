using Abp.EntityFrameworkCore.Configuration;
using Abp.IdentityServer4;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using IdentityServer4.EntityFramework.DbContexts;
using Zya.IdentityServer.EntityFrameworkCore.Seed;

namespace Zya.IdentityServer.EntityFrameworkCore
{
    [DependsOn(
        typeof(IdentityServerCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule),
        typeof(AbpZeroCoreIdentityServerEntityFrameworkCoreModule))]
    public class IdentityServerEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<IdentityServerDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        IdentityServerDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        IdentityServerDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServerEntityFrameworkModule).GetAssembly());
            //IocManager.Register<ConfigurationDbContext>(Abp.Dependency.DependencyLifeStyle.Transient);
            //IocManager.Register<IdentityServerConfigurationDbContext>(Abp.Dependency.DependencyLifeStyle.Transient);
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
                SeedHelper.SeedIdentityServerDb(new IdentityServerConfigurationDbContextFactory().CreateDbContext(null));
                
            }
        }
    }
}
