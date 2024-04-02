using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Extensions.Mappings
{
    public static class EmployeesExtensions
    {
        public static Employee ToEmployee(this EmployeeDto dto) => new Employee()
        {
            Id = dto.EmployeeId,
            Name = dto.FirstName,
        };

        public static Employee ToEmployee(this EmployeeCreateDto dto) => new Employee()
        {
            Id = dto.EmployeeId,
            Name = dto.FirstName,
        };
        public static Employee ToEmployee(this EmployeeUpdateDto dto, int id) => new Employee()
        {
            Id = dto.EmployeeId,
            Name = dto.FirstName,          
        };

        public static EmployeeDto ToDto(this Employee Employee) => new EmployeeDto
        {
            EmployeeId = Employee.Id,
            FirstName = Employee.Name,
        };

        public static IEnumerable<EmployeeDto>ToDtoList (this IEnumerable<Employee> EmployeeList) => EmployeeList.Select(Employee => Employee.ToDto()).ToList();

        //public static ICatalog<EmployeeDto> ToDto(this ICatalog<Employee> EmployeeList) => new Catalog<EmployeeDto>(EmployeeList.List.ToDto());
    }
}
