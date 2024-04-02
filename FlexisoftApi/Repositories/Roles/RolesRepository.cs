using Dapper;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles.Dao;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Roles
{
    internal class RolesRepository : IRolesReader, IRolesCommand
    {
        private const string RoleTableName = "tblWMODCORE001_Roles";
        //private readonly IDbConnection<RolesRepository> _dbConnection;

        //public RolesRepository(IDbConnection<RolesRepository> sqlConnection)
        //{
        //    _dbConnection = sqlConnection;
        //}

        //public async Task<ICatalog<RoleDao>> GetRolesAsync(ICatalogFilter filter)
        //{
        //    var query = $"SELECT Roles.ID AS Id, Roles.NOM as Name FROM {RoleTableName} AS Roles";

        //    var RoleDaoList = await _dbConnection.QueryAsync<RoleDao>(query);

        //    return new Catalog<RoleDao>(RoleDaoList.ToList(), filter);
        //}

        public Task<RoleDao> GetRoleByNameAsync(string name)
        {
            var query = $"SELECT Roles.ID AS Id, Roles.NOM as Name FROM {RoleTableName} AS Roles";
            throw new NotImplementedException();
            //return _dbConnection.QueryFirstOrDefaultAsync<RoleDao>($"{query} WHERE NOM = @name", new { name });
        }

        public Task<RoleDao> GetRoleByIdAsync(int id)
        {
            var query = $"SELECT Roles.ID AS Id, Roles.NOM as Name FROM {RoleTableName} AS Roles";
            throw new NotImplementedException();
            //return _dbConnection.QueryFirstOrDefaultAsync<RoleDao>($"{query} WHERE Id = @id", new { id });
        }

        public async Task<RoleDao> AddRoleAsync(RoleDao Role)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RoleDao> UpdateRoleAsync(RoleDao Role)
        {
            throw new NotImplementedException();
        }
    }
}
