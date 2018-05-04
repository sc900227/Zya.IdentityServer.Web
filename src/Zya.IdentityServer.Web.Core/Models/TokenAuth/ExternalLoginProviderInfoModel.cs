using Abp.AutoMapper;
using Zya.IdentityServer.Authentication.External;

namespace Zya.IdentityServer.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
