using FluentValidation;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Api;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Cors;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Swagger;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Contracts;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core
{
    public static class CoreExtensions
    {
        public static IMvcBuilder BuildControllersConfiguration(this IMvcBuilder mvcBuilder)
        {
            // ActionFilter par defaut pour récuperer son ordre
            var modelStateInvalidFilter = new ModelStateInvalidFilter(new ApiBehaviorOptions { InvalidModelStateResponseFactory = context => new OkResult() }, NullLogger.Instance);
            mvcBuilder.AddMvcOptions(options =>
            {
                // ActionFilter de validation (passage avant les autres ActionFilter)
                //options.Filters.Add<ValidateModelStateAsyncActionFilter>(modelStateInvalidFilter.Order - 1);
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                // Correction de la serialisation json pour le dictionnaire d'erreur
                //options.InvalidModelStateResponseFactory = options.InvalidModelStateResponseFactoryWithJsonSerializedDictionary();
            });

            //mvcBuilder.Services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
            //mvcBuilder.Services.AddFluentValidationRulesToSwagger();

            return mvcBuilder;
        }

        public static IApplicationBuilder UseCoreConfiguration(this IApplicationBuilder app, IConfiguration configuration, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            app.UseCorsPolicies(configuration);
            app.UseSwaggerConfig(configuration, apiVersionDescriptionProvider);



            return app;
        }

        public static IApplicationBuilder UseCustomErrorHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorMiddleware>();
        }

        public static IServiceCollection AddCoreConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddCorsConfiguration(configuration);
            services.AddApiVersioningConfig();
            services.AddSwaggerServices(configuration, environment);
            return services;
        }

        public static IServiceCollection AddAplCreationContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddCreationService((provider, configure) =>
            //{
            //    var apiConfiguration = provider.GetService<IOptions<ApiConfiguration>>();
            //    configure.CreationName = apiConfiguration.Value.CreationCourante;
            //});

            //services.AddTransient<IAplCreationContexte>(provider =>
            //{
            //    var apiConfiguration = provider.GetService<IOptions<ApiConfiguration>>();
            //    return new AplCreationContexte(provider.GetService<ICreationService>(), apiConfiguration.Value.AplCourante, apiConfiguration.Value.ApplicationName);
            //});

            return services;
        }
    }
}
