using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Zya.IdentityServer.Configuration;
using Zya.IdentityServer.Web;

namespace Zya.IdentityServer.EntityFrameworkCore
{
    public class IdentityServerConfigurationDbContextFactory :IDesignTimeDbContextFactory<IdentityServerConfigurationDbContext>
    {
        public IdentityServerConfigurationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IdentityServerConfigurationDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
            var connString = configuration.GetConnectionString(IdentityServerConsts.ConnectionStringName);
            IdentityServerDbContextConfigurer.Configure(builder, connString);

            ConfigurationStoreOptions storeOptions = new ConfigurationStoreOptions();
            storeOptions.ConfigureDbContext = builder1 =>
                         builder1.UseMySql(connString, sql => sql.MigrationsAssembly("Zya.IdentityServer.EntityFrameworkCore"));

            return new IdentityServerConfigurationDbContext(builder.Options, storeOptions);
        }
    }
}
