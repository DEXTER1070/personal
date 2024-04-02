using FluentAssertions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Tests.Core;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients.Models;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Tests.Controllers
{
    public class ClientsControllersTests : WebApiControllerTestsBase
    {
        private readonly IClientsService _clientsService;

        public ClientsControllersTests(ApiApplicationFactory<StartupTest> factory) : base(factory)
        {
            _clientsService = GetService<IClientsService>();
        }

        [Fact]
        public async Task CreateClientPostApi_ModelStateIsInvalid_ReturnsBadRequestResult()
        {
            var clientCreateDto = new ClientCreateDto()
            {
                Name = $"Nom Test 1"
            };

            var response = await PostAsync("clients", clientCreateDto);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var errors = await GetValidationErrors(response);

            errors.Should().Contain("Ce nom est déjà utilisé");
        }

        [Fact]
        public async Task CreateClientPostApi_ModelStateIsValid_ReturnsOk()
        {
            //var clientCreateDto = await _clientsService.GetClientsAsync(new CatalogFilter());

            var newName = "Nom Test /*{clientCreateDto.List.Count + 1}*/";

            var dto = new ClientCreateDto()
            {
                Name = newName,
            };

            var response = await PostAsync("clients", dto);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var client = await _clientsService.GetClientByNameAsync(newName);

            client.Should().NotBeNull();
            client.Name.Should().Be(newName);
            client.Should().BeOfType<Client>();
        }
    }
}
