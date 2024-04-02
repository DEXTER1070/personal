using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Filters;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Extensions.Mappings;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Controllers
{
    [Produces("application/json")]
    [ApiController, Route("api/v{version:apiVersion}/[controller]"), ApiVersion("1.0", Deprecated = false)]
    [AuthorizationToken]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        //[HttpGet("")]
        //[Produces(typeof(Catalog<ClientDto>))]
        //public async Task<IActionResult> GetClients([FromQuery] CatalogFilter filter)
        //{
        //    var clientList = await _clientsService.GetClientsAsync(filter);

        //    var clientCatalog = clientList.ToDto();

        //    return Ok(clientCatalog);
        //}

        [HttpGet("{id:int}", Name = nameof(GetClientById))]
        [Produces(typeof(ClientDto))]
        public async Task<IActionResult> GetClientById([FromRoute] int id)
        {
            var client = await _clientsService.GetClientByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client.ToDto());
        }

        [HttpGet("find")]
        [Produces(typeof(ClientDto))]
        public async Task<IActionResult> FindClient([FromQuery] string name)
        {
            var client = await _clientsService.GetClientByNameAsync(name);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client.ToDto());
        }

        [HttpPost("")]
        [Produces(typeof(ClientDto))]
        public async Task<IActionResult> CreateClient([FromBody] ClientCreateDto clientCreate)
        {
            var insertedClientResult = await _clientsService.AddClientAsync(clientCreate.ToClient());

            var routeUrl = Url.RouteUrl(nameof(GetClientById), new { id = insertedClientResult.Id });

            return Created($"{routeUrl}", insertedClientResult.ToDto());
        }

        [HttpPut("{id:int}")]
        [Produces(typeof(ClientDto))]
        public async Task<IActionResult> UpdateClient([FromRoute] int id, [FromBody] ClientUpdateDto clientUpdate)
        {
            if (id != clientUpdate.Id)
            {
                ModelState.AddModelError(nameof(clientUpdate.Id), $"Ids Mismatch");
                return ValidationProblem(ModelState);
            }

            var updatedClientResult = await _clientsService.UpdateClientAsync(clientUpdate.ToClient(id));

            return Ok(updatedClientResult.ToDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteClientById([FromRoute] int id)
        {
            var deletedClientResult = await _clientsService.DeleteClientAsync(id);

            if (!deletedClientResult)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
