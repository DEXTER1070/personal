using FluentAssertions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees.Dao;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Employees.Extensions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Tests
{
    public class EmployeesServiceTests
    {
        IEmployeesService EmployeesService;

        public EmployeesServiceTests()
        {
            var EmployeesRepository = new EmployeesRepository(new Repositories.Mock.DB.EmployeesDB());

            EmployeesService = new EmployeesService(EmployeesRepository, EmployeesRepository);
        }

        [Fact]
        public async Task GetEmployeesAsync_With_NoFilter_Return_Full_List()
        {
            //var EmployeeCatalog = await EmployeesService.GetEmployeesAsync(new CatalogFilter());

            //EmployeeCatalog.Should().NotBeNull();
            //EmployeeCatalog.Should().BeOfType<Catalog<Employee>>();
            //EmployeeCatalog.List.Should().NotBeNull();
            //EmployeeCatalog.Total.Should().Be(300);
            //EmployeeCatalog.TotalFiltered.Should().Be(300);
        }

        [Fact]
        public async Task GetEmployeesAsync_With_Filter_Return_Full_List()
        {
            //var EmployeeCatalog = await EmployeesService.GetEmployeesAsync(new CatalogFilter()
            //{
            //    PageIndex = 1,
            //    PageSize = 5,
            //    SortByName = "Name",
            //    SortDirection = System.ComponentModel.ListSortDirection.Descending,
            //    Search = "Nom Test 1"
            //});

            //EmployeeCatalog.Should().NotBeNull();
            //EmployeeCatalog.Should().BeOfType<Catalog<Employee>>();
            //EmployeeCatalog.List.Should().NotBeNull();
            //EmployeeCatalog.Total.Should().Be(300);
            //EmployeeCatalog.TotalFiltered.Should().Be(111);
            //EmployeeCatalog.List.Count.Should().Be(5);
            //EmployeeCatalog.List.First().Id.Should().Be(194);
            //EmployeeCatalog.List.First().Name.Should().Be("Nom Test 194");
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_Return_GoodElement()
        {
            var Employee = await EmployeesService.GetEmployeeByEmployeeIdAsync(1);

            Employee.Should().NotBeNull();
            Employee.Should().BeOfType<Employee>();
            Employee.Id.Should().Be(1);
            Employee.Name.Should().Be("Nom Test 1");
        }

        [Fact]
        public async Task GetEmployeeByNameAsync_Return_GoodElement()
        {
            var Employee = await EmployeesService.GetEmployeeByFirstNameAsync("Nom Test 2");

            Employee.Should().NotBeNull();
            Employee.Should().BeOfType<Employee>();
            Employee.Id.Should().Be(2);
            Employee.Name.Should().Be("Nom Test 2");
        }

        [Fact]
        public async Task AddEmployeeAsync_Return_NewElementAdd()
        {
            var newEntity = new Employee()
            {
                Id = 31,
                Name = "Nom Test 31"
            };

            var Employee = await EmployeesService.AddEmployeeAsync(newEntity);

            Employee.Should().NotBeNull();
            Employee.Should().BeOfType<Employee>();
            Employee.Id.Should().Be(newEntity.Id);
            Employee.Name.Should().Be(newEntity.Name);

            var checkEmployee = await EmployeesService.GetEmployeeByEmployeeIdAsync(newEntity.Id);

            checkEmployee.Should().NotBeNull();
            checkEmployee.Should().BeOfType<Employee>();
            checkEmployee.Id.Should().Be(newEntity.Id);
            checkEmployee.Name.Should().Be(newEntity.Name);
        }

        [Fact]
        public async Task UpdateEmployeeAsync_Return_UpdatedElement()
        {
            var updatedEntity = new Employee()
            {
                Id = 14,
                Name = "My New Name"
            };

            var Employee = await EmployeesService.UpdateEmployeeAsync(updatedEntity);

            Employee.Should().NotBeNull();
            Employee.Should().BeOfType<Employee>();
            Employee.Id.Should().Be(updatedEntity.Id);
            Employee.Name.Should().Be(updatedEntity.Name);

            var checkEmployee = await EmployeesService.GetEmployeeByEmployeeIdAsync(updatedEntity.Id);

            checkEmployee.Should().NotBeNull();
            checkEmployee.Should().BeOfType<Employee>();
            checkEmployee.Id.Should().Be(updatedEntity.Id);
            checkEmployee.Name.Should().Be(updatedEntity.Name);
        }


        [Fact]
        public async Task DeleteEmployeeAsync_Return_True()
        {
            var newEntity = new Employee()
            {
                Id = 302,
                Name = "Nom Test 302"
            };

            await EmployeesService.AddEmployeeAsync(newEntity);

            var isDeleted = await EmployeesService.DeleteEmployeeAsync(302);

            isDeleted.Should().BeTrue();

            var checkEmployee = await EmployeesService.GetEmployeeByEmployeeIdAsync(302);

            checkEmployee.Should().BeNull();
        }
    }
}
