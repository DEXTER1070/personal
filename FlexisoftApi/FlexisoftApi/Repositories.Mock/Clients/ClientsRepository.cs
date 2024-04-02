using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients.Dao;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.DB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.Clients
{
    public class ClientsRepository : IClientsReader, IClientsCommand
    {
        private readonly ClientsDB _db;

        public ClientsRepository(ClientsDB db)
        {
            _db = db;
        }

        public async Task<ClientDao> AddClientAsync(ClientDao client)
        {
            _db.Add(client);

            var dbClient = _db.Clients.FirstOrDefault(c => c.Name.ToLowerInvariant() == client.Name.ToLowerInvariant());

            return await Task.FromResult(dbClient);
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = _db.Clients.First(client => client.Id == id);

            _db.Clients.Remove(client);

            return await Task.FromResult(true);
        }

        public async Task<ClientDao> GetClientByNameAsync(string name)
        {
            var client = _db.Clients.FirstOrDefault(c => c.Name.ToLowerInvariant() == name.ToLowerInvariant());

            return await Task.FromResult(client);
        }

        public async Task<ClientDao> GetClientByIdAsync(int id)
        {
            var client = _db.Clients.FirstOrDefault(c => c.Id == id);

            return await Task.FromResult(client);
        }

        //public async Task<ICatalog<ClientDao>> GetClientsAsync(ICatalogFilter filter)
        //{
        //    return await Task.FromResult(new Catalog<ClientDao>(_db.Clients, filter));
        //}

        public async Task<ClientDao> UpdateClientAsync(ClientDao client)
        {
            await DeleteClientAsync(client.Id);

            _db.Add(client);

            return client;
        }
       
    }
}
