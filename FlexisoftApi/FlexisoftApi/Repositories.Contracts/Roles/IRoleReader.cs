using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles.Dao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles
{
    public interface IRolesReader
    {
        Task<RoleDao> GetRoleByIdAsync(int id);
        Task<RoleDao> GetRoleByNameAsync(string name);
        // Task<ICatalog<RoleDao>> GetRolesAsync(ICatalogFilter filter);
    }
}
