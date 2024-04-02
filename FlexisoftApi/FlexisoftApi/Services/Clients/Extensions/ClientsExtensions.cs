using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients.Dao;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Clients.Extensions
{
    public static class ClientsExtensions
    {
        public static Client ToClient(this ClientDao dao) => new Client()
        {
            Id = dao.Id,
            Name = dao.Name
        };

        //public static Catalog<Client> ToClient(this ICatalog<ClientDao> dao)
        //{
        //    var clients = dao.List.ToClientList();
        //    return new Catalog<Client>(clients, dao.Total, dao.TotalFiltered);
        //}

        public static List<Client> ToClientList(this IEnumerable<ClientDao> daoList) => daoList.Select(dao => dao.ToClient()).ToList();

        public static ClientDao ToDao(this Client client) => new ClientDao(client.Id, client.Name);
    }
}