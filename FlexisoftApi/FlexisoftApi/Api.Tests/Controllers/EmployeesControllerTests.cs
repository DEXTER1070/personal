using FluentAssertions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Tests.Core;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees.Models;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Tests.Controllers
{
    public class EmployeesControllersTests : WebApiControllerTestsBase
    {
        private readonly IEmployeesService _EmployeesService;

        public EmployeesControllersTests(ApiApplicationFactory<StartupTest> factory) : base(factory)
        {
            _EmployeesService = GetService<IEmployeesService>();
        }

        [Fact]
        public async Task CreateEmployeePostApi_ModelStateIsInvalid_ReturnsBadRequestResult()
        {
            var EmployeeCreateDto = new EmployeeCreateDto()
            {
                FirstName = $"Nom Test 1"
            };

            var response = await PostAsync("Employees", EmployeeCreateDto);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var errors = await GetValidationErrors(response);

            errors.Should().Contain("Ce nom est déjà utilisé");
        }

        [Fact]
        public async Task CreateEmployeePostApi_ModelStateIsValid_ReturnsOk()
        {
            //var EmployeeCreateDto = await _EmployeesService.GetEmployeesAsync(new CatalogFilter());

            var newName = "Nom Test /*{EmployeeCreateDto.List.Count + 1}*/";

            var dto = new EmployeeCreateDto()
            {
                FirstName = newName,
            };

            var response = await PostAsync("Employees", dto);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var Employee = await _EmployeesService.GetEmployeeByFirstNameAsync(newName);

            Employee.Should().NotBeNull();
            Employee.Name.Should().Be(newName);
            Employee.Should().BeOfType<Employee>();
        }
    }
}
