using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees.Dao;
using System.Collections.Generic;
using System.Linq;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.DB
{
    public class EmployeesDB
    {
        private List<EmployeeDao> _Employees { get; set; }

        public EmployeesDB()
        {
            _Employees = new List<EmployeeDao>();

            for (var i = 1; i <= 300; i++)
            {
                var Employee = new EmployeeDao()
                {
                    Id = i,
                    Name = $"Nom Test {i}"
                };

                _Employees.Add(Employee);
            }
        }

        public List<EmployeeDao> Employees => _Employees;

        public EmployeeDao Add(EmployeeDao Employee)
        {
            _Employees.Add(Employee);

            var dbEmployee = this._Employees.FirstOrDefault(c => c.Name.ToLowerInvariant() == Employee.Name.ToLowerInvariant());

            return dbEmployee;
        }
    }
}
