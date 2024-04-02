using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var openApiInfo = new OpenApiInfo()
            {
                Title = $"FlexisoftApi API - {description.GroupName.ToLowerInvariant()}",
                Version = description.ApiVersion.ToString(),
            };

            if (description.IsDeprecated)
            {
                openApiInfo.Description += " Cette API est dépreciée";
            }

            return openApiInfo;
        }
    }
}