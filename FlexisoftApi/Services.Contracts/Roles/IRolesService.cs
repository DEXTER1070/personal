using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles.Models;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles
{
    public interface IRolesService
    {
        //Task<ICatalog<Role>> GetRolesAsync(ICatalogFilter filter);
        Task<Role> GetRoleByIdAsync(int id);
        Task<Role> GetRoleByNameAsync(string name);
        Task<Role> AddRoleAsync(Role Role);
        Task<bool> DeleteRoleAsync(int id);
        Task<Role> UpdateRoleAsync(Role Role);
    }
}