using Abp.Dependency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zya.IdentityServer.EntityFrameworkCore
{
    public class IdentityServerConfigurationDbContextOption: ISingletonDependency
    {
        public DbContextOptions<IdentityServerConfigurationDbContext> GetDbContextOption()
        {
            var builder = new DbContextOptionsBuilder<IdentityServerConfigurationDbContext>();
            //var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            //MyDocumentManageDbContextConfigurer.Configure(builder, configuration.GetConnectionString("mydb"));

            IdentityServerDbContextConfigurer.Configure(builder, AppConfigurtaionServices.GetAppSettings()["ConnectionStrings:mydb"]);
            return builder.Options;
        }
    }
}
