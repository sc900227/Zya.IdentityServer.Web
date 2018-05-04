using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using Zya.IdentityServer.EntityFrameworkCore.Seed.Host;
using Zya.IdentityServer.EntityFrameworkCore.Seed.Tenants;
using IdentityServer4.EntityFramework.DbContexts;
using Zya.IdentityServer.EntityFrameworkCore.Seed.IdentityServer;

namespace Zya.IdentityServer.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        public static void SeedHostDb(IIocResolver iocResolver)
        {
            WithDbContext<IdentityServerDbContext>(iocResolver, SeedHostDb);
        }

        public static void SeedHostDb(IdentityServerDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            // Host seed
            new InitialHostDbBuilder(context).Create();

            // Default tenant seed (in host database).
            new DefaultTenantBuilder(context).Create();
            new TenantRoleAndUserBuilder(context, 1).Create();
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Tenant);

                    contextAction(context);

                    uow.Complete();
                }
            }
        }

        public static void SeedIdentityServerDb(IIocResolver iocResolver)
        {
            WithDbContext<IdentityServerConfigurationDbContext>(iocResolver, SeedIdentityServerDb);
        }

        public static void SeedIdentityServerDb(IdentityServerConfigurationDbContext context)
        {
            new InitialIConfigurationDbBuilder(context).Create();
        }
    }
}
