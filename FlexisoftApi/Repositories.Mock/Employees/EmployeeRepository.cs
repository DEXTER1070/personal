using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees.Dao;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.DB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.Employees
{
    public class EmployeesRepository : IEmployeesReader, IEmployeesCommand
    {
        private readonly EmployeesDB _db;

        public EmployeesRepository(EmployeesDB db)
        {
            _db = db;
        }

        //SCHEMATICS FOR THE METHODS BELOW ARE IN THE IEmployeesReader INTERFACE ABOVE AND THE EmployeeDao CLASS IN THE DAO FOLDER
        public async Task<EmployeeDao> GetEmployeeByEmployeeIdAsync(int EMPLOYEE_ID)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Id == EMPLOYEE_ID);

            return await Task.FromResult(Employee);
        }

        public async Task<EmployeeDao> AddEmployeeAsync(EmployeeDao Employee)
        {
            _db.Add(Employee);

            var dbEmployee = _db.Employees.FirstOrDefault(c => c.Name.ToLowerInvariant() == Employee.Name.ToLowerInvariant());

            return await Task.FromResult(dbEmployee);
        }

        public async Task<bool> DeleteEmployeeAsync(int EMPLOYEE_ID)
        {
            var Employee = _db.Employees.First(Employee => Employee.Id == EMPLOYEE_ID);

            _db.Employees.Remove(Employee);

            return await Task.FromResult(true);
        }

        public async Task<EmployeeDao> GetEmployeeByFirstNameAsync(string FIRST_NAME)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Name.ToLowerInvariant() == FIRST_NAME.ToLowerInvariant());

            return await Task.FromResult(Employee);
        }
        public async Task<EmployeeDao> GetEmployeeBySurnameAsync(string SURNAME)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Name.ToLowerInvariant() == SURNAME.ToLowerInvariant());

            return await Task.FromResult(Employee);
        }
        public async Task<EmployeeDao> GetEmployeeByEmailAsync(string EMAIL)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Name.ToLowerInvariant() == EMAIL.ToLowerInvariant());

            return await Task.FromResult(Employee);
        }
        public async Task<EmployeeDao> GetEmployeeByPasswordAsync(string PASSWORD)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Name.ToLowerInvariant() == PASSWORD.ToLowerInvariant());

            return await Task.FromResult(Employee);
        }
        public async Task<EmployeeDao> GetEmployeeByDOBAsync(int DOB)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Id == DOB);

            return await Task.FromResult(Employee);
        }
        public async Task<EmployeeDao> GetEmployeeByHiredDateAsync(int HIRE_DATE)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Id == HIRE_DATE);

            return await Task.FromResult(Employee);
        }
        public async Task<EmployeeDao> GetEmployeeByGenderAsync(string GENDER)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Name.ToLowerInvariant() == GENDER.ToLowerInvariant());

            return await Task.FromResult(Employee);
        }
        public async Task<EmployeeDao> GetEmployeeByContactAsync(int CONTACT_NUMBER)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Id == CONTACT_NUMBER);

            return await Task.FromResult(Employee);
        }
        public async Task<EmployeeDao> GetEmployeeByEmergencyContactAsync(int EMERGENCY_CONTACT_NUMBER)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Id == EMERGENCY_CONTACT_NUMBER);

            return await Task.FromResult(Employee);
        }

        public async Task<EmployeeDao> GetEmployeeByTeamIDAsync(int TEAM_ID)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Id == TEAM_ID);

            return await Task.FromResult(Employee);
        }
        public async Task<EmployeeDao> GetEmployeeByTeamNameAsync(string TEAM_NAME)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Name.ToLowerInvariant() == TEAM_NAME.ToLowerInvariant());

            return await Task.FromResult(Employee);
        }
        public async Task<EmployeeDao> GetEmployeeByRoleIDAsync(int ROLE_ID)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Id == ROLE_ID);

            return await Task.FromResult(Employee);
        }
        public async Task<EmployeeDao> GetEmployeeByRoleNameAsync(string ROLE_NAME)
        {
            var Employee = _db.Employees.FirstOrDefault(c => c.Name.ToLowerInvariant() == ROLE_NAME.ToLowerInvariant());

            return await Task.FromResult(Employee);
        }

        //public async Task<ICatalog<EmployeeDao>> GetEmployeesAsync(ICatalogFilter filter)
        //{
        //    return await Task.FromResult(new Catalog<EmployeeDao>(_db.Employees, filter));
        //}

        public async Task<EmployeeDao> UpdateEmployeeAsync(EmployeeDao Employee)
        {
            await DeleteEmployeeAsync(Employee.Id);

            _db.Add(Employee);

            return Employee;
        }

        public Task<EmployeeDao> GetEmployeeByDOBAsync(string DOB)
        {
            throw new System.NotImplementedException();
        }

        public Task<EmployeeDao> GetEmployeeByHiredDateAsync(string HIRE_DATE)
        {
            throw new System.NotImplementedException();
        }
    }
}
