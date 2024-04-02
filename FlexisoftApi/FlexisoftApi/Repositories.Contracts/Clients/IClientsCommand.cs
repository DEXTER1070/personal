using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients.Dao;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients
{
    public interface IClientsCommand
    {
        Task<ClientDao> AddClientAsync(ClientDao client);
        Task<bool> DeleteClientAsync(int id);
        Task<ClientDao> UpdateClientAsync(ClientDao client);
    }
}