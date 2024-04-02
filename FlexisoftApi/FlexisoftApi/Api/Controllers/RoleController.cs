using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Filters;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Extensions.Mappings;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Controllers
{
    [Produces("application/json")]
    [ApiController, Route("api/v{version:apiVersion}/[controller]"), ApiVersion("1.0", Deprecated = false)]
    [AuthorizationToken]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _RolesService;

        public RolesController(IRolesService RolesService)
        {
            _RolesService = RolesService;
        }

        //[HttpGet("")]
        //[Produces(typeof(Catalog<RoleDto>))]
        //public async Task<IActionResult> GetRoles([FromQuery] CatalogFilter filter)
        //{
        //    var RoleList = await _RolesService.GetRolesAsync(filter);

        //    var RoleCatalog = RoleList.ToDto();

        //    return Ok(RoleCatalog);
        //}

        [HttpGet("{id:int}", Name = nameof(GetRoleById))]
        [Produces(typeof(RoleDto))]
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            var Role = await _RolesService.GetRoleByIdAsync(id);

            if (Role == null)
            {
                return NotFound();
            }

            return Ok(Role.ToDto());
        }

        [HttpGet("find")]
        [Produces(typeof(RoleDto))]
        public async Task<IActionResult> FindRole([FromQuery] string name)
        {
            var Role = await _RolesService.GetRoleByNameAsync(name);

            if (Role == null)
            {
                return NotFound();
            }

            return Ok(Role.ToDto());
        }

        [HttpPost("")]
        [Produces(typeof(RoleDto))]
        public async Task<IActionResult> CreateRole([FromBody] RoleCreateDto RoleCreate)
        {
            var insertedRoleResult = await _RolesService.AddRoleAsync(RoleCreate.ToRole());

            var routeUrl = Url.RouteUrl(nameof(GetRoleById), new { id = insertedRoleResult.Id });

            return Created($"{routeUrl}", insertedRoleResult.ToDto());
        }

        [HttpPut("{id:int}")]
        [Produces(typeof(RoleDto))]
        public async Task<IActionResult> UpdateRole([FromRoute] int id, [FromBody] RoleUpdateDto RoleUpdate)
        {
            if (id != RoleUpdate.Id)
            {
                ModelState.AddModelError(nameof(RoleUpdate.Id), $"Ids Mismatch");
                return ValidationProblem(ModelState);
            }

            var updatedRoleResult = await _RolesService.UpdateRoleAsync(RoleUpdate.ToRole(id));

            return Ok(updatedRoleResult.ToDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRoleById([FromRoute] int id)
        {
            var deletedRoleResult = await _RolesService.DeleteRoleAsync(id);

            if (!deletedRoleResult)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
