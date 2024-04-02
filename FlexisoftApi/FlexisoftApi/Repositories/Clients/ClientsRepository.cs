using Dapper;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients.Dao;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Clients
{
    internal class ClientsRepository : IClientsReader, IClientsCommand
    {
        private const string ClientTableName = "tblWMODCORE001_Clients";
        //private readonly IDbConnection<ClientsRepository> _dbConnection;

        //public ClientsRepository(IDbConnection<ClientsRepository> sqlConnection)
        //{
        //    _dbConnection = sqlConnection;
        //}

        //public async Task<ICatalog<ClientDao>> GetClientsAsync(ICatalogFilter filter)
        //{
        //    var query = $"SELECT Clients.ID AS Id, Clients.NOM as Name FROM {ClientTableName} AS Clients";

        //    var clientDaoList = await _dbConnection.QueryAsync<ClientDao>(query);

        //    return new Catalog<ClientDao>(clientDaoList.ToList(), filter);
        //}

        public Task<ClientDao> GetClientByNameAsync(string name)
        {
            var query = $"SELECT Clients.ID AS Id, Clients.NOM as Name FROM {ClientTableName} AS Clients";
            throw new NotImplementedException();
            //return _dbConnection.QueryFirstOrDefaultAsync<ClientDao>($"{query} WHERE NOM = @name", new { name });
        }

        public Task<ClientDao> GetClientByIdAsync(int id)
        {
            var query = $"SELECT Clients.ID AS Id, Clients.NOM as Name FROM {ClientTableName} AS Clients";
            throw new NotImplementedException();
            //return _dbConnection.QueryFirstOrDefaultAsync<ClientDao>($"{query} WHERE Id = @id", new { id });
        }

        public async Task<ClientDao> AddClientAsync(ClientDao client)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ClientDao> UpdateClientAsync(ClientDao client)
        {
            throw new NotImplementedException();
        }
    }
}
