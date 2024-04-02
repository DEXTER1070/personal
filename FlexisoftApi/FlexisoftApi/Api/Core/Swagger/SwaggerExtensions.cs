using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Swagger
{
    public static class SwaggerExtensions
    {
        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, IConfiguration configuration, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            var enableSwagger = configuration.GetValue<bool>("enableSwagger");

            if (enableSwagger)
            {
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.InjectStylesheet("../css/swagger.css");

                    apiVersionDescriptionProvider.ApiVersionDescriptions.ToList().ForEach(description =>
                    {
                        options.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    });
                });
            }

            return app;
        }

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var enableSwagger = configuration.GetValue<bool>("enableSwagger");

            if (enableSwagger)
            {
                services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

                var apiConfiguration = configuration.Get<ApiConfiguration>();

                services.AddSwaggerGen(
                  options =>
                  {
                      options.OperationFilter<SwaggerDefaultValues>();
                      options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                      options.AddSecurityDefinition(FlexisoftApi.Contracts.Constants.Environment.AuhtorizationTokenVariableName, new OpenApiSecurityScheme()
                      {
                          Name = FlexisoftApi.Contracts.Constants.Environment.AuhtorizationTokenVariableName,
                          Type = SecuritySchemeType.ApiKey,
                          Scheme = SecuritySchemeType.ApiKey.ToString(),
                          In = ParameterLocation.Header,
                          BearerFormat = "XXXX-XXXX-XXXX-XXXX",
                          Description = !environment.IsProduction()
                          ? $"<div>Enter the following key <span>{apiConfiguration.ApiSecret}</span></div>"
                          : ""
                      });

                      options.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                      {
                        new OpenApiSecurityScheme
                        {
                            Name = FlexisoftApi.Contracts.Constants.Environment.AuhtorizationTokenVariableName,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id =   FlexisoftApi.Contracts.Constants.Environment.AuhtorizationTokenVariableName
                            },
                        },
                        new string[] { apiConfiguration.ApiSecret }
                    }
                        });

                  });
            }

            return services;
        }
    }
}