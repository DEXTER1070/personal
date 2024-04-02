using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Employees.Extensions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Employees
{
    internal class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesReader _EmployeesReader;
        private readonly IEmployeesCommand _EmployeesCommand;

        public EmployeesService(IEmployeesReader EmployeesReader, IEmployeesCommand EmployeesCommand)
        {
            _EmployeesReader = EmployeesReader;
            _EmployeesCommand = EmployeesCommand;
        }

        public async Task<Employee> AddEmployeeAsync(Employee Employee)
        {
            var createdEmployeeDao = await _EmployeesCommand.AddEmployeeAsync(Employee.ToDao());

            return createdEmployeeDao.ToEmployee();
        }

        public async Task<bool> DeleteEmployeeAsync(int EMPLOYEE_ID)
        {
            return await _EmployeesCommand.DeleteEmployeeAsync(EMPLOYEE_ID);
        }

        public async Task<Employee> GetEmployeeByEmployeeIdAsync(int EMPLOYEE_ID)
        {
            var EmployeeDao = await _EmployeesReader.GetEmployeeByEmployeeIdAsync(EMPLOYEE_ID);

            return EmployeeDao?.ToEmployee();
        }

        public async Task<Employee> GetEmployeeByTeamIDAsync(int TEAM_ID)
        {
            var EmployeeDao = await _EmployeesReader.GetEmployeeByTeamIDAsync(TEAM_ID);

            return EmployeeDao?.ToEmployee();
        }

        public async Task<Employee> GetEmployeeByRoleIDAsync(int ROLE_ID)
        {
            var EmployeeDao = await _EmployeesReader.GetEmployeeByRoleIDAsync(ROLE_ID);

            return EmployeeDao?.ToEmployee();
        }

        public async Task<Employee> GetEmployeeByFirstNameAsync(string FIRST_NAME)
        {
            var EmployeeDao = await _EmployeesReader.GetEmployeeByFirstNameAsync(FIRST_NAME);

            return EmployeeDao?.ToEmployee();
        }

        public async Task<Employee> GetEmployeeBySurnameAsync(string SURNAME)
        {
            var EmployeeDao = await _EmployeesReader.GetEmployeeBySurnameAsync(SURNAME);

            return EmployeeDao?.ToEmployee();
        }

        public async Task<Employee> GetEmployeeByEmailAsync(string EMAIL)
        {
            var EmployeeDao = await _EmployeesReader.GetEmployeeByEmailAsync(EMAIL);

            return EmployeeDao?.ToEmployee();
        }

        public async Task<Employee> GetEmployeeByContactAsync(int CONTACT_NUMBER)
        {
            var EmployeeDao = await _EmployeesReader.GetEmployeeByContactAsync(CONTACT_NUMBER);

            return EmployeeDao?.ToEmployee();
        }

        public async Task<Employee> GetEmployeeByEmergencyContactAsync(int EMERGENCY_CONTACT_NUMBER)
        {
            var EmployeeDao = await _EmployeesReader.GetEmployeeByContactAsync(EMERGENCY_CONTACT_NUMBER);

            return EmployeeDao?.ToEmployee();
        }

        //public async Task<ICatalog<Employee>> GetEmployeesAsync(ICatalogFilter filter)
        //{
        //    var EmployeeDaoCatalog = await _EmployeesReader.GetEmployeesAsync(filter);
        //    return EmployeeDaoCatalog.ToEmployee();
        //}

        public async Task<Employee> UpdateEmployeeAsync(Employee Employee)
        {
            var updatedEmployeeDao = await _EmployeesCommand.UpdateEmployeeAsync(Employee.ToDao());

            return updatedEmployeeDao.ToEmployee();
        }

        public Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
