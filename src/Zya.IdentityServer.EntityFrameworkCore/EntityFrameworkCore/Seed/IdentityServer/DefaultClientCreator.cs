using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zya.IdentityServer.EntityFrameworkCore.Seed.IdentityServer
{
    public class DefaultClientCreator
    {
        private readonly IdentityServerConfigurationDbContext _context;

        public DefaultClientCreator(IdentityServerConfigurationDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultClient();
        }

        private void CreateDefaultClient()
        {
            if (_context.Clients.Any()) return;
            foreach (var client in GetClients())
            {
                _context.Clients.Add(client.ToEntity());
            }
            _context.SaveChanges();
        }

        private static IEnumerable<Client> GetClients() => new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes =
                    {
                        GrantType.ResourceOwnerPassword,
                        GrantType.ClientCredentials
                    },
                    AllowedScopes = {"default-api"},
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
    }
}
