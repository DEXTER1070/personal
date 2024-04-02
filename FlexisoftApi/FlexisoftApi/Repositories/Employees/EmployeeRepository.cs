using Dapper;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Employees
{
    internal class EmployeesRepository : IEmployeesReader, IEmployeesCommand
    {
        private const string EmployeeTableName = "tblWMODCORE001_Employees";
        private readonly IDbConnection _dbConnection;

        public EmployeesRepository(IDbConnection sqlConnection)
        {
            _dbConnection = sqlConnection;
        }

        public async Task<IEnumerable<EmployeeDao>> GetEmployeesAsync()
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} AS Employees";

            return await _dbConnection.QueryAsync<EmployeeDao>(query);
        }

        public async Task<EmployeeDao> GetEmployeeByFirstNameAsync(string FIRST_NAME)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE NOM = @FirstName";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { FirstName = FIRST_NAME });
        }


        public async Task<EmployeeDao> GetEmployeeBySurnameAsync(string SURNAME)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE SurnameColumn = @Surname";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { Surname = SURNAME });
        }

        public async Task<EmployeeDao> GetEmployeeByEmailAsync(string EMAIL)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name, Employees.EMAIL as Email FROM {EmployeeTableName} WHERE EMAIL = @Email";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { Email = EMAIL });
        }
        public async Task<EmployeeDao> GetEmployeeByPasswordAsync(string PASSWORD)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE PasswordColumn = @Password";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { Password = PASSWORD });
        }

        public async Task<EmployeeDao> GetEmployeeByDOBAsync(string DOB)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE DOBColumn = @DOB";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { DOB });
        }
        public async Task<EmployeeDao> GetEmployeeByHiredDateAsync(string HIRE_DATE)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE HiredDateColumn = @HireDate";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { HireDate = HIRE_DATE });
        }

        public async Task<EmployeeDao> GetEmployeeByGenderAsync(string GENDER)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE GenderColumn = @Gender";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { Gender = GENDER });
        }

        public async Task<EmployeeDao> GetEmployeeByEmployeeIdAsync(int EMPLOYEE_ID)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE ID = @EmployeeId";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { EmployeeId = EMPLOYEE_ID });
        }

        public async Task<EmployeeDao> GetEmployeeByTeamIDAsync(int TEAM_ID)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE TeamIDColumn = @TeamId";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { TeamId = TEAM_ID });
        }

        public async Task<IEnumerable<EmployeeDao>> GetEmployeeByTeamNameAsync(string TEAM_NAME)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE TeamNameColumn = @TeamName";
            return await _dbConnection.QueryAsync<EmployeeDao>(query, new { TeamName = TEAM_NAME });
        }

        public async Task<EmployeeDao> GetEmployeeByRoleIDAsync(int ROLE_ID)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE RoleIDColumn = @RoleId";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { RoleId = ROLE_ID });
        }
        public async Task<IEnumerable<EmployeeDao>> GetEmployeeByRoleNameAsync(string ROLE_NAME)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE RoleNameColumn = @RoleName";
            return await _dbConnection.QueryAsync<EmployeeDao>(query, new { RoleName = ROLE_NAME });
        }
        public async Task<EmployeeDao> GetEmployeeByContactAsync(string CONTACT_NUMBER)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE ContactNumberColumn = @ContactNumber";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { ContactNumber = CONTACT_NUMBER});
        }

        public async Task<EmployeeDao> GetEmployeeByEmergencyContactAsync(string EMERGENCY_CONTACT_NUMBER)
        {
            var query = $"SELECT Employees.ID AS Id, Employees.NOM as Name FROM {EmployeeTableName} WHERE EmergencyContactNumberColumn = @EmergencyContactNumber";
            return await _dbConnection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { EmergencyContactNumber = EMERGENCY_CONTACT_NUMBER });
        }
     
        public async Task<EmployeeDao> AddEmployeeAsync(EmployeeDao Employee)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEmployeeAsync(int EMPLOYEE_ID)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeDao> UpdateEmployeeAsync(EmployeeDao Employee)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDao> GetEmployeeByContactAsync(int CONTACT_NUMBER)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDao> GetEmployeeByEmergencyContactAsync(int EMERGENCY_CONTACT_NUMBER)
        {
            throw new NotImplementedException();
        }

        Task<EmployeeDao> IEmployeesReader.GetEmployeeByTeamNameAsync(string TEAM_NAME)
        {
            throw new NotImplementedException();
        }

        Task<EmployeeDao> IEmployeesReader.GetEmployeeByRoleNameAsync(string ROLE_NAME)
        {
            throw new NotImplementedException();
        }
    }
}
