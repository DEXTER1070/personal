namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Employees
{
    public record EmployeeUpdateDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int DOB { get; set; }
        public int HireDate { get; set; }
        public bool Gender { get; set; }
        public int Contact { get; set; }
        public int EmergencyContact { get; set; }
    }
}
