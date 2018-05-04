using IdentityServer4.EntityFramework.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zya.IdentityServer.EntityFrameworkCore.Seed.IdentityServer
{
    public class InitialIConfigurationDbBuilder
    {
        private readonly IdentityServerConfigurationDbContext _context;

        public InitialIConfigurationDbBuilder(IdentityServerConfigurationDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultApiResourceCreator(_context).Create();
            new DefaultIdentityResourceCreator(_context).Create();
            new DefaultClientCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
