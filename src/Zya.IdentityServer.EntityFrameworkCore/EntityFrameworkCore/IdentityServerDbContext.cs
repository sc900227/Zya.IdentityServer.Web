using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Zya.IdentityServer.Authorization.Roles;
using Zya.IdentityServer.Authorization.Users;
using Zya.IdentityServer.MultiTenancy;
using Abp.IdentityServer4;

namespace Zya.IdentityServer.EntityFrameworkCore
{
    public class IdentityServerDbContext : AbpZeroDbContext<Tenant, Role, User, IdentityServerDbContext>,IAbpPersistedGrantDbContext
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<PersistedGrantEntity> PersistedGrants { get; set; }
        public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}
