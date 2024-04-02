using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients.Dao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients
{
    public interface IClientsReader
    {
        Task<ClientDao> GetClientByIdAsync(int id);
        Task<ClientDao> GetClientByNameAsync(string name);
       // Task<ICatalog<ClientDao>> GetClientsAsync(ICatalogFilter filter);
    }
}
