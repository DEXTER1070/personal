using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Cors
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                var corsConfiguration = configuration.GetSection(nameof(CorsConfiguration)).Get<CorsConfiguration>();

                foreach (var policy in corsConfiguration.Policies)
                {

                    options.AddPolicy(policy.Name, builder =>
                    {
                        builder.WithOrigins(policy.AllowedOrigins != null ? policy.AllowedOrigins?.ToArray() : new List<string>().ToArray())
                               .WithMethods(policy.AllowedMethods != null ? policy.AllowedMethods?.ToArray() : new List<string>().ToArray())
                               .AllowAnyHeader();
                    });
                }
            });

            return services;
        }

        public static IApplicationBuilder UseCorsPolicies(this IApplicationBuilder app, IConfiguration configuration)
        {
            var corsConfiguration = configuration.GetSection(nameof(CorsConfiguration)).Get<CorsConfiguration>();

            foreach (var policy in corsConfiguration.Policies)
            {
                app.UseCors(policy.Name);
            }

            return app;
        }
    }
}