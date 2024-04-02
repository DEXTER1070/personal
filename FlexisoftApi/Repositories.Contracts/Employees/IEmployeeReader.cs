using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees.Dao;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees
{
    public interface IEmployeesReader
    {
        Task<EmployeeDao> GetEmployeeByEmployeeIdAsync(int EMPLOYEE_ID);
        Task<EmployeeDao> GetEmployeeByFirstNameAsync(string FIRST_NAME);
        Task<EmployeeDao> GetEmployeeBySurnameAsync(string SURNAME);
        Task<EmployeeDao> GetEmployeeByEmailAsync(string EMAIL);
        Task<EmployeeDao> GetEmployeeByPasswordAsync(string PASSWORD);
        Task<EmployeeDao> GetEmployeeByDOBAsync(string DOB);
        Task<EmployeeDao> GetEmployeeByGenderAsync(string GENDER);
        Task<EmployeeDao> GetEmployeeByHiredDateAsync(string HIRE_DATE);
        Task<EmployeeDao> GetEmployeeByContactAsync(int CONTACT_NUMBER);
        Task<EmployeeDao> GetEmployeeByEmergencyContactAsync(int EMERGENCY_CONTACT_NUMBER);
        Task<EmployeeDao> GetEmployeeByTeamIDAsync(int TEAM_ID);
        Task<EmployeeDao> GetEmployeeByTeamNameAsync(string TEAM_NAME);
        Task<EmployeeDao> GetEmployeeByRoleIDAsync(int ROLE_ID);
        Task<EmployeeDao> GetEmployeeByRoleNameAsync(string ROLE_NAME);

        //Task<ICatalog<EmployeeDao>> GetEmployeesAsync(ICatalogFilter filter);
    }
}
