using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByEmployeeIdAsync(int EMPLOYEE_ID);
        Task<Employee> GetEmployeeByTeamIDAsync(int TEAM_ID);
        Task<Employee> GetEmployeeByRoleIDAsync(int ROLE_ID);
        Task<Employee> GetEmployeeByFirstNameAsync(string FIRST_NAME);
        Task<Employee> GetEmployeeBySurnameAsync(string SURNAME);
        Task<Employee> GetEmployeeByEmailAsync(string EMAIL);
        Task<Employee> GetEmployeeByContactAsync(int CONTACT_NUMBER);
        Task<Employee> GetEmployeeByEmergencyContactAsync(int EMERGENCY_CONTACT_NUMBER);

        Task<Employee> AddEmployeeAsync(Employee Employee);
        Task<bool> DeleteEmployeeAsync(int EMPLOYEE_ID);
        Task<Employee> UpdateEmployeeAsync(Employee Employee);
    }
}