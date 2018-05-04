using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zya.IdentityServer.EntityFrameworkCore.Seed.IdentityServer
{
    public class DefaultApiResourceCreator
    {
        private readonly IdentityServerConfigurationDbContext _context;

        public DefaultApiResourceCreator(IdentityServerConfigurationDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultApiResource();
        }

        private void CreateDefaultApiResource()
        {
            if (_context.ApiResources.Any()) return;
            var defaultApiResource = new ApiResource() { Name = "default-api", DisplayName = "Default (all) API" };
            _context.ApiResources.Add(defaultApiResource);
            _context.SaveChanges();
        }
    }
}
