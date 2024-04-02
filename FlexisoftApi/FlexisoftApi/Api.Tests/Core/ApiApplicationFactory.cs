using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Linq;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Tests.Core
{
    public class ApiApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public ApiApplicationFactory()
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var path = GetHostedWebSiteContentRoot();

            builder = builder.UseEnvironment("Test")
                .UseContentRoot(path)
                .UseWebRoot($"{path}\\wwwroot");

            base.ConfigureWebHost(builder);
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder<TStartup>(null);
        }

        private string GetHostedWebSiteContentRoot()
        {
            var location = typeof(Startup).Assembly.Location;
            var assemblyName = typeof(Startup).Assembly.GetName().Name;
            var path = location.Replace($"{assemblyName}.dll", "", System.StringComparison.OrdinalIgnoreCase);

            path = string.Join("\\", path.Split("\\").Take(path.Split("\\").Length - 4)).TrimEnd('\\').TrimEnd('\\')
                     .Replace(".Tests", "", System.StringComparison.OrdinalIgnoreCase);

            return path;
        }
    }
}


