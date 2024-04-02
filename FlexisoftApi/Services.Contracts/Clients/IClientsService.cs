using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients.Models;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients
{
    public interface IClientsService
    {
        //Task<ICatalog<Client>> GetClientsAsync(ICatalogFilter filter);
        Task<Client> GetClientByIdAsync(int id);
        Task<Client> GetClientByNameAsync(string name);
        Task<Client> AddClientAsync(Client client);
        Task<bool> DeleteClientAsync(int id);
        Task<Client> UpdateClientAsync(Client client);
    }
}