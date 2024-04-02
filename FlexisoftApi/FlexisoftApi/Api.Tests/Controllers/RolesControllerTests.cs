using FluentAssertions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Tests.Core;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles.Models;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Tests.Controllers
{
    public class RolesControllersTests : WebApiControllerTestsBase
    {
        private readonly IRolesService _RolesService;

        public RolesControllersTests(ApiApplicationFactory<StartupTest> factory) : base(factory)
        {
            _RolesService = GetService<IRolesService>();
        }

        [Fact]
        public async Task CreateRolePostApi_ModelStateIsInvalid_ReturnsBadRequestResult()
        {
            var RoleCreateDto = new RoleCreateDto()
            {
                Name = $"Nom Test 1"
            };

            var response = await PostAsync("Roles", RoleCreateDto);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var errors = await GetValidationErrors(response);

            errors.Should().Contain("Ce nom est déjà utilisé");
        }

        [Fact]
        public async Task CreateRolePostApi_ModelStateIsValid_ReturnsOk()
        {
            //var RoleCreateDto = await _RolesService.GetRolesAsync(new CatalogFilter());

            var newName = "Nom Test /*{RoleCreateDto.List.Count + 1}*/";

            var dto = new RoleCreateDto()
            {
                Name = newName,
            };

            var response = await PostAsync("Roles", dto);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var Role = await _RolesService.GetRoleByNameAsync(newName);

            Role.Should().NotBeNull();
            Role.Name.Should().Be(newName);
            Role.Should().BeOfType<Role>();
        }
    }
}
