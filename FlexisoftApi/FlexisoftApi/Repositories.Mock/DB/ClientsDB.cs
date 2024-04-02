using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients.Dao;
using System.Collections.Generic;
using System.Linq;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.DB
{
    public class ClientsDB
    {
        private List<ClientDao> _clients { get; set; }

        public ClientsDB()
        {
            _clients = new List<ClientDao>();

            for (var i = 1; i <= 300; i++)
            {
                var client = new ClientDao()
                {
                    Id = i,
                    Name = $"Nom Test {i}"
                };

                _clients.Add(client);
            }
        }

        public List<ClientDao> Clients => _clients;

        public ClientDao Add(ClientDao client)
        {
            _clients.Add(client);

            var dbClient = this._clients.FirstOrDefault(c => c.Name.ToLowerInvariant() == client.Name.ToLowerInvariant());

            return dbClient;
        }
    }
}
