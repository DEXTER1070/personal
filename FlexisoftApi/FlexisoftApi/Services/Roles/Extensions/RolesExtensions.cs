using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles.Dao;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Roles.Extensions
{
    public static class RolesExtensions
    {
        public static Role ToRole(this RoleDao dao) => new Role()
        {
            Id = dao.Id,
            Name = dao.Name
        };

        //public static Catalog<Role> ToRole(this ICatalog<RoleDao> dao)
        //{
        //    var Roles = dao.List.ToRoleList();
        //    return new Catalog<Role>(Roles, dao.Total, dao.TotalFiltered);
        //}

        public static List<Role> ToRoleList(this IEnumerable<RoleDao> daoList) => daoList.Select(dao => dao.ToRole()).ToList();

        public static RoleDao ToDao(this Role Role) => new RoleDao(Role.Id, Role.Name);
    }
}