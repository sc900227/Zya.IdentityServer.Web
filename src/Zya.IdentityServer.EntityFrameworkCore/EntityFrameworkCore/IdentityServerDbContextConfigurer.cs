using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Zya.IdentityServer.EntityFrameworkCore
{
    public static class IdentityServerDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IdentityServerDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
            //builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IdentityServerDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
            //builder.UseSqlServer(connection);
        }

        public static void Configure(DbContextOptionsBuilder<IdentityServerConfigurationDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
            //builder.UseSqlServer(connectionString);
        }
        public static void Configure(DbContextOptionsBuilder<IdentityServerConfigurationDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
            //builder.UseSqlServer(connection);
        }
    }
}
