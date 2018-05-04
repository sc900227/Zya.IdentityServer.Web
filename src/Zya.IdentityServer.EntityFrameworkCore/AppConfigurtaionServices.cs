using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zya.IdentityServer
{
    public class AppConfigurtaionServices
    {
        public static IConfiguration GetAppSettings()
        {
            IConfiguration Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();

            return Configuration;
        }
    }
}
