using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles.Dao;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.DB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.Roles
{
    public class RolesRepository : IRolesReader, IRolesCommand
    {
        private readonly RolesDB _db;

        public RolesRepository(RolesDB db)
        {
            _db = db;
        }

        public async Task<RoleDao> AddRoleAsync(RoleDao Role)
        {
            _db.Add(Role);

            var dbRole = _db.Roles.FirstOrDefault(c => c.Name.ToLowerInvariant() == Role.Name.ToLowerInvariant());

            return await Task.FromResult(dbRole);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var Role = _db.Roles.First(Role => Role.Id == id);

            _db.Roles.Remove(Role);

            return await Task.FromResult(true);
        }

        public async Task<RoleDao> GetRoleByNameAsync(string name)
        {
            var Role = _db.Roles.FirstOrDefault(c => c.Name.ToLowerInvariant() == name.ToLowerInvariant());

            return await Task.FromResult(Role);
        }

        public async Task<RoleDao> GetRoleByIdAsync(int id)
        {
            var Role = _db.Roles.FirstOrDefault(c => c.Id == id);

            return await Task.FromResult(Role);
        }

        //public async Task<ICatalog<RoleDao>> GetRolesAsync(ICatalogFilter filter)
        //{
        //    return await Task.FromResult(new Catalog<RoleDao>(_db.Roles, filter));
        //}

        public async Task<RoleDao> UpdateRoleAsync(RoleDao Role)
        {
            await DeleteRoleAsync(Role.Id);

            _db.Add(Role);

            return Role;
        }

    }
}
