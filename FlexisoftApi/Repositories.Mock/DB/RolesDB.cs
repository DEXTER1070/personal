using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles.Dao;
using System.Collections.Generic;
using System.Linq;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.DB
{
    public class RolesDB
    {
        private List<RoleDao> _Roles { get; set; }

        public RolesDB()
        {
            _Roles = new List<RoleDao>();

            for (var i = 1; i <= 300; i++)
            {
                var Role = new RoleDao()
                {
                    Id = i,
                    Name = $"Nom Test {i}"
                };

                _Roles.Add(Role);
            }
        }

        public List<RoleDao> Roles => _Roles;

        public RoleDao Add(RoleDao Role)
        {
            _Roles.Add(Role);

            var dbRole = this._Roles.FirstOrDefault(c => c.Name.ToLowerInvariant() == Role.Name.ToLowerInvariant());

            return dbRole;
        }
    }
}
