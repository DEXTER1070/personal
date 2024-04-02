using Microsoft.Extensions.DependencyInjection;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Api
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddApiVersioningConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(
              options =>
              {
                  options.GroupNameFormat = "'v'VVV";
                  options.SubstituteApiVersionInUrl = true;
              });
            return services;
        }
    }
}
