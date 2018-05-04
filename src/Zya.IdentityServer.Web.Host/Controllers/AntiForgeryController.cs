using Microsoft.AspNetCore.Antiforgery;
using Zya.IdentityServer.Controllers;

namespace Zya.IdentityServer.Web.Host.Controllers
{
    public class AntiForgeryController : IdentityServerControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
