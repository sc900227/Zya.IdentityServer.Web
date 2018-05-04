using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zya.IdentityServer.EntityFrameworkCore.Seed.IdentityServer
{
    public class DefaultIdentityResourceCreator
    {
        private readonly IdentityServerConfigurationDbContext _context;

        public DefaultIdentityResourceCreator(IdentityServerConfigurationDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultIdentityResource();
        }

        private void CreateDefaultIdentityResource()
        {
            if (_context.IdentityResources.Any()) return;
            foreach (var resource in GetIdentityResource())
            {
                _context.IdentityResources.Add(resource.ToEntity());
            }
            _context.SaveChanges();
        }

        private static IEnumerable<IdentityServer4.Models.IdentityResource> GetIdentityResource()
        {
            return new List<IdentityServer4.Models.IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone()
            };

        }
    }
}
