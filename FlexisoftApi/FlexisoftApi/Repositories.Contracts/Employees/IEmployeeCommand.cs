using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees.Dao;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees
{
    public interface IEmployeesCommand
    {
        Task<EmployeeDao> AddEmployeeAsync(EmployeeDao Employee);
        Task<bool> DeleteEmployeeAsync(int EMPLOYEE_ID);
        Task<EmployeeDao> GetEmployeeByFirstNameAsync(string FIRSTNAME);
        Task<EmployeeDao> GetEmployeeByGenderAsync(string GENDER);
        Task<EmployeeDao> UpdateEmployeeAsync(EmployeeDao Employee);
    }
}