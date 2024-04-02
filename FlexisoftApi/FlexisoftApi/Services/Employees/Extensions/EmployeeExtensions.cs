using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees.Dao;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Employees.Extensions
{
    public static class EmployeesExtensions
    {
        public static Employee ToEmployee(this EmployeeDao dao) => new Employee()
        {
            Id = dao.Id,
            Name = dao.Name
        };

        //public static Catalog<Employee> ToEmployee(this ICatalog<EmployeeDao> dao)
        //{
        //    var Employees = dao.List.ToEmployeeList();
        //    return new Catalog<Employee>(Employees, dao.Total, dao.TotalFiltered);
        //}

        public static List<Employee> ToEmployeeList(this IEnumerable<EmployeeDao> daoList) => daoList.Select(dao => dao.ToEmployee()).ToList();

        public static EmployeeDao ToDao(this Employee Employee) => new EmployeeDao(Employee.Id, Employee.Name);
    }
}