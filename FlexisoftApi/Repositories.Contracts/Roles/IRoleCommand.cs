using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles.Dao;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles
{
    public interface IRolesCommand
    {
        Task<RoleDao> AddRoleAsync(RoleDao Role);
        Task<bool> DeleteRoleAsync(int id);
        Task<RoleDao> UpdateRoleAsync(RoleDao Role);
    }
}