using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Filters;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Extensions.Mappings;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Controllers
{
    [Produces("application/json")]
    [ApiController, Route("api/v{version:apiVersion}/[controller]"), ApiVersion("1.0", Deprecated = false)]
    [AuthorizationToken]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _EmployeesService;

        public EmployeesController(IEmployeesService EmployeesService)
        {
            _EmployeesService = EmployeesService;
        }

        [HttpGet("")]
        [Produces(typeof(IEnumerable<EmployeeDto>))]
        public async Task<IActionResult> GetEmployees()
        {
            var EmployeeList = await _EmployeesService.GetEmployeesAsync();

            var EmployeeCatalog = EmployeeList.ToDtoList();

            return Ok(EmployeeCatalog);
        }

        [HttpGet("{id:int}", Name = nameof(GetEmployeeById))]
        [Produces(typeof(EmployeeDto))]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var Employee = await _EmployeesService.GetEmployeeByEmployeeIdAsync(id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Ok(Employee.ToDto());
        }

        [HttpGet("find")]
        [Produces(typeof(EmployeeDto))]
        public async Task<IActionResult> FindEmployee([FromQuery] string name)
        {
            var Employee = await _EmployeesService.GetEmployeeByFirstNameAsync(name);

            if (Employee == null)
            {
                return NotFound();
            }

            return Ok(Employee.ToDto());
        }

        [HttpPost("")]
        [Produces(typeof(EmployeeDto))]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto EmployeeCreate)
        {
            var insertedEmployeeResult = await _EmployeesService.AddEmployeeAsync(EmployeeCreate.ToEmployee());

            var routeUrl = Url.RouteUrl(nameof(GetEmployeeById), new { id = insertedEmployeeResult.Id });

            return Created($"{routeUrl}", insertedEmployeeResult.ToDto());
        }

        [HttpPut("{id:int}")]
        [Produces(typeof(EmployeeDto))]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] EmployeeUpdateDto EmployeeUpdate)
        {
            if (id != EmployeeUpdate.EmployeeId)
            {
                ModelState.AddModelError(nameof(EmployeeUpdate.EmployeeId), $"Ids Mismatch");
                return ValidationProblem(ModelState);
            }

            var updatedEmployeeResult = await _EmployeesService.UpdateEmployeeAsync(EmployeeUpdate.ToEmployee(id));

            return Ok(updatedEmployeeResult.ToDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployeeById([FromRoute] int id)
        {
            var deletedEmployeeResult = await _EmployeesService.DeleteEmployeeAsync(id);

            if (!deletedEmployeeResult)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
