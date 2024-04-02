using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Clients.Extensions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients.Models;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Clients
{
    internal class ClientsService : IClientsService
    {
        private readonly IClientsReader _clientsReader;
        private readonly IClientsCommand _clientsCommand;

        public ClientsService(IClientsReader clientsReader, IClientsCommand clientsCommand)
        {
            _clientsReader = clientsReader;
            _clientsCommand = clientsCommand;
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            var createdClientDao = await _clientsCommand.AddClientAsync(client.ToDao());

            return createdClientDao.ToClient();
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            return await _clientsCommand.DeleteClientAsync(id);
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            var clientDao = await _clientsReader.GetClientByIdAsync(id);

            return clientDao?.ToClient();
        }

        public async Task<Client> GetClientByNameAsync(string name)
        {
            var clientDao = await _clientsReader.GetClientByNameAsync(name);

            return clientDao?.ToClient();
        }

        //public async Task<ICatalog<Client>> GetClientsAsync(ICatalogFilter filter)
        //{
        //    var clientDaoCatalog = await _clientsReader.GetClientsAsync(filter);
        //    return clientDaoCatalog.ToClient();
        //}

        public async Task<Client> UpdateClientAsync(Client client)
        {
            var updatedClientDao = await _clientsCommand.UpdateClientAsync(client.ToDao());

            return updatedClientDao.ToClient();
        }
    }
}
