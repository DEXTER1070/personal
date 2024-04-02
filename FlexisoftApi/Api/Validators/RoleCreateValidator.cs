using FluentValidation;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles;
using MicroElements.Swashbuckle.FluentValidation;
using System.Collections.Generic;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Validators
{
    public class RoleCreateValidator : AbstractValidator<RoleCreateDto>
    {
        public RoleCreateValidator(IRolesService RolesService)
        {
            CascadeMode = CascadeMode.Stop;
            var nameAllreadyUsedError = "Ce nom est déjà utilisé";

            //RuleFor(Role => Role.Name).Input(nameof(RoleCreateDto.Name), new ValidatorBaseSettings(true, 6, 25));

            RuleFor(Role => Role.Name).MustAsync(async (model, name, cancelationToken) =>
            {
                var Role = await RolesService.GetRoleByNameAsync(model.Name);

                return Role == null;
            }).WithMessage(nameAllreadyUsedError);
        }

        public static List<FluentValidationRule> GetRules()
        {
            var list = new List<FluentValidationRule>();

            //list.Add(InputValidator.GetFluentValidationRule<RoleCreateDto>());

            return list;
        }
    }
}