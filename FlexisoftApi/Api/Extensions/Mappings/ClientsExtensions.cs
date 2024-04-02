using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Extensions.Mappings
{
    public static class ClientsExtensions
    {
        public static Client ToClient(this ClientDto dto) => new Client()
        {
            Id = dto.Id,
            Name = dto.Name
        };

        public static Client ToClient(this ClientCreateDto dto) => new Client()
        {
            Name = dto.Name
        };

        public static Client ToClient(this ClientUpdateDto dto, int id) => new Client()
        {
            Id = id,
            Name = dto.Name
        };

        public static ClientDto ToDto(this Client client) => new ClientDto
        {
            Id = client.Id,
            Name = client.Name
        };

        public static List<ClientDto> ToDto(this List<Client> clientList) => clientList.Select(client => client.ToDto()).ToList();

        //public static ICatalog<ClientDto> ToDto(this ICatalog<Client> clientList) => new Catalog<ClientDto>(clientList.List.ToDto());
    }
}
