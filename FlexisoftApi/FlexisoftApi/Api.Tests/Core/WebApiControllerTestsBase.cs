using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Tests.Core
{
    public abstract class WebApiControllerTestsBase : IClassFixture<ApiApplicationFactory<StartupTest>>
    {
        private const string ApiVersion = "1.0";

        private readonly WebApplicationFactory<StartupTest> _factory;
        private readonly HttpClient _httpClient;
        private readonly ApiConfiguration _apiConfiguration;

        protected WebApiControllerTestsBase(ApiApplicationFactory<StartupTest> factory)
        {
            _apiConfiguration = factory.Services.GetService<IOptions<ApiConfiguration>>().Value;
            _factory = factory;
            _httpClient = _factory.CreateClient();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(_apiConfiguration.ApiSecret);
        }

        protected T GetService<T>() => _factory.Server.Host.Services.GetService<T>();

        protected Task<HttpResponseMessage> PostAsync<TDto>(string relativeUrl, TDto dto)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            return _httpClient.PostAsync($"/api/v{ApiVersion}/{relativeUrl}", jsonContent);
        }

        protected async Task<List<string>> GetValidationErrors(HttpResponseMessage response)
        {
            var validationString = await response.Content.ReadAsStringAsync();

            var validationproblems = JsonSerializer.Deserialize<ValidationProblemDetails>(
                validationString,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            return validationproblems.Errors.SelectMany(e => e.Value).ToList();
        }
    }
}
