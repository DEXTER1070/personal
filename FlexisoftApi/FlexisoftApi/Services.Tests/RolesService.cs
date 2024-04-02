using FluentAssertions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles.Dao;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Roles.Extensions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Tests
{
    public class RolesServiceTests
    {
        IRolesService RolesService;

        public RolesServiceTests()
        {
            var RolesRepository = new RolesRepository(new Repositories.Mock.DB.RolesDB());

            RolesService = new RolesService(RolesRepository, RolesRepository);
        }

        [Fact]
        public async Task GetRolesAsync_With_NoFilter_Return_Full_List()
        {
            //var RoleCatalog = await RolesService.GetRolesAsync(new CatalogFilter());

            //RoleCatalog.Should().NotBeNull();
            //RoleCatalog.Should().BeOfType<Catalog<Role>>();
            //RoleCatalog.List.Should().NotBeNull();
            //RoleCatalog.Total.Should().Be(300);
            //RoleCatalog.TotalFiltered.Should().Be(300);
        }

        [Fact]
        public async Task GetRolesAsync_With_Filter_Return_Full_List()
        {
            //var RoleCatalog = await RolesService.GetRolesAsync(new CatalogFilter()
            //{
            //    PageIndex = 1,
            //    PageSize = 5,
            //    SortByName = "Name",
            //    SortDirection = System.ComponentModel.ListSortDirection.Descending,
            //    Search = "Nom Test 1"
            //});

            //RoleCatalog.Should().NotBeNull();
            //RoleCatalog.Should().BeOfType<Catalog<Role>>();
            //RoleCatalog.List.Should().NotBeNull();
            //RoleCatalog.Total.Should().Be(300);
            //RoleCatalog.TotalFiltered.Should().Be(111);
            //RoleCatalog.List.Count.Should().Be(5);
            //RoleCatalog.List.First().Id.Should().Be(194);
            //RoleCatalog.List.First().Name.Should().Be("Nom Test 194");
        }

        [Fact]
        public async Task GetRoleByIdAsync_Return_GoodElement()
        {
            var Role = await RolesService.GetRoleByIdAsync(1);

            Role.Should().NotBeNull();
            Role.Should().BeOfType<Role>();
            Role.Id.Should().Be(1);
            Role.Name.Should().Be("Nom Test 1");
        }

        [Fact]
        public async Task GetRoleByNameAsync_Return_GoodElement()
        {
            var Role = await RolesService.GetRoleByNameAsync("Nom Test 2");

            Role.Should().NotBeNull();
            Role.Should().BeOfType<Role>();
            Role.Id.Should().Be(2);
            Role.Name.Should().Be("Nom Test 2");
        }

        [Fact]
        public async Task AddRoleAsync_Return_NewElementAdd()
        {
            var newEntity = new Role()
            {
                Id = 31,
                Name = "Nom Test 31"
            };

            var Role = await RolesService.AddRoleAsync(newEntity);

            Role.Should().NotBeNull();
            Role.Should().BeOfType<Role>();
            Role.Id.Should().Be(newEntity.Id);
            Role.Name.Should().Be(newEntity.Name);

            var checkRole = await RolesService.GetRoleByIdAsync(newEntity.Id);

            checkRole.Should().NotBeNull();
            checkRole.Should().BeOfType<Role>();
            checkRole.Id.Should().Be(newEntity.Id);
            checkRole.Name.Should().Be(newEntity.Name);
        }

        [Fact]
        public async Task UpdateRoleAsync_Return_UpdatedElement()
        {
            var updatedEntity = new Role()
            {
                Id = 14,
                Name = "My New Name"
            };

            var Role = await RolesService.UpdateRoleAsync(updatedEntity);

            Role.Should().NotBeNull();
            Role.Should().BeOfType<Role>();
            Role.Id.Should().Be(updatedEntity.Id);
            Role.Name.Should().Be(updatedEntity.Name);

            var checkRole = await RolesService.GetRoleByIdAsync(updatedEntity.Id);

            checkRole.Should().NotBeNull();
            checkRole.Should().BeOfType<Role>();
            checkRole.Id.Should().Be(updatedEntity.Id);
            checkRole.Name.Should().Be(updatedEntity.Name);
        }


        [Fact]
        public async Task DeleteRoleAsync_Return_True()
        {
            var newEntity = new Role()
            {
                Id = 302,
                Name = "Nom Test 302"
            };

            await RolesService.AddRoleAsync(newEntity);

            var isDeleted = await RolesService.DeleteRoleAsync(302);

            isDeleted.Should().BeTrue();

            var checkRole = await RolesService.GetRoleByIdAsync(302);

            checkRole.Should().BeNull();
        }
    }
}
