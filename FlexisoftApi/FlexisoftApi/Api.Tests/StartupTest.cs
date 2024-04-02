using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Tests
{
    public class StartupTest : Startup
    {
        public StartupTest(Microsoft.Extensions.Configuration.IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment)
        {
        }

        public override void ConfigureRepositories(IServiceCollection services)
        {
            services.AddApplicationMockedRespositories();
        }
    }
}
