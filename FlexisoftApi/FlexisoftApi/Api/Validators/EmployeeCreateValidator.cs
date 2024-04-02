using FluentValidation;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees;
using MicroElements.Swashbuckle.FluentValidation;
using System.Collections.Generic;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Validators
{
    public class EmployeeCreateValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateValidator(IEmployeesService EmployeesService)
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            //CascadeMode = CascadeMode.Stop;   //review this line
            var nameAllreadyUsedError = "Ce nom est déjà utilisé";

            //RuleFor(Employee => Employee.Name).Input(nameof(EmployeeCreateDto.Name), new ValidatorBaseSettings(true, 6, 25));

            RuleFor(Employee => Employee.FirstName).MustAsync(async (model, name, cancelationToken) =>
            {
                var Employee = await EmployeesService.GetEmployeeByFirstNameAsync(model.FirstName);

                return Employee == null;
            }).WithMessage(nameAllreadyUsedError);
        }

        public static List<FluentValidationRule> GetRules()
        {
            var list = new List<FluentValidationRule>();

            //list.Add(InputValidator.GetFluentValidationRule<EmployeeCreateDto>());

            return list;
        }
    }
}