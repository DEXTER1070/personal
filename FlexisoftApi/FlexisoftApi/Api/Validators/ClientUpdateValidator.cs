using FluentValidation;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients;
using MicroElements.Swashbuckle.FluentValidation;
using System.Collections.Generic;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Validators
{
    public class ClientUpdateValidator : AbstractValidator<ClientUpdateDto>
    {
        public ClientUpdateValidator(IClientsService clientsService)
        {
            CascadeMode = CascadeMode.Stop;
            var nameAllreadyUsedError = "Ce nom est déjà utilisé";

           // RuleFor(client => client.Name).Input(nameof(ClientUpdateDto.Name), new ValidatorBaseSettings(true, 6, 25));

            RuleFor(client => client.Name).MustAsync(async (model, name, cancelationToken) =>
            {
                var client = await clientsService.GetClientByNameAsync(model.Name);

                return client == null;
            }).WithMessage(nameAllreadyUsedError);
        }

        public static List<FluentValidationRule> GetRules()
        {
            var list = new List<FluentValidationRule>();

            //list.Add(InputValidator.GetFluentValidationRule<ClientUpdateDto>());

            return list;
        }
    }
}