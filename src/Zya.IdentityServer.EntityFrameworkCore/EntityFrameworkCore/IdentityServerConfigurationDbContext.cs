using Abp.Dependency;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zya.IdentityServer.EntityFrameworkCore
{
    public class IdentityServerConfigurationDbContext : ConfigurationDbContext<IdentityServerConfigurationDbContext>
    {
        
        public IdentityServerConfigurationDbContext(DbContextOptions<IdentityServerConfigurationDbContext> options,ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //...

                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
