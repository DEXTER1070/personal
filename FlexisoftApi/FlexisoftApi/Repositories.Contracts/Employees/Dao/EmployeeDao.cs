namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees.Dao
{
    public class EmployeeDao
    {
        internal EmployeeDao()
        {
        }
        internal EmployeeDao(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
