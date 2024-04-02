using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Roles.Extensions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles.Models;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Roles
{
    internal class RolesService : IRolesService
    {
        private readonly IRolesReader _RolesReader;
        private readonly IRolesCommand _RolesCommand;

        public RolesService(IRolesReader RolesReader, IRolesCommand RolesCommand)
        {
            _RolesReader = RolesReader;
            _RolesCommand = RolesCommand;
        }

        public async Task<Role> AddRoleAsync(Role Role)
        {
            var createdRoleDao = await _RolesCommand.AddRoleAsync(Role.ToDao());

            return createdRoleDao.ToRole();
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await _RolesCommand.DeleteRoleAsync(id);
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            var RoleDao = await _RolesReader.GetRoleByIdAsync(id);

            return RoleDao?.ToRole();
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            var RoleDao = await _RolesReader.GetRoleByNameAsync(name);

            return RoleDao?.ToRole();
        }

        //public async Task<ICatalog<Role>> GetRolesAsync(ICatalogFilter filter)
        //{
        //    var RoleDaoCatalog = await _RolesReader.GetRolesAsync(filter);
        //    return RoleDaoCatalog.ToRole();
        //}

        public async Task<Role> UpdateRoleAsync(Role Role)
        {
            var updatedRoleDao = await _RolesCommand.UpdateRoleAsync(Role.ToDao());

            return updatedRoleDao.ToRole();
        }
    }
}
