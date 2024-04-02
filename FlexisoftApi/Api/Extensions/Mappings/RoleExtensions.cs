using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Extensions.Mappings
{
    public static class RolesExtensions
    {
        public static Role ToRole(this RoleDto dto) => new Role()
        {
            Id = dto.Id,
            Name = dto.Name
        };

        public static Role ToRole(this RoleCreateDto dto) => new Role()
        {
            Name = dto.Name
        };

        public static Role ToRole(this RoleUpdateDto dto, int id) => new Role()
        {
            Id = id,
            Name = dto.Name
        };

        public static RoleDto ToDto(this Role Role) => new RoleDto
        {
            Id = Role.Id,
            Name = Role.Name
        };

        public static List<RoleDto> ToDto(this List<Role> RoleList) => RoleList.Select(Role => Role.ToDto()).ToList();

        //public static ICatalog<RoleDto> ToDto(this ICatalog<Role> RoleList) => new Catalog<RoleDto>(RoleList.List.ToDto());
    }
}
