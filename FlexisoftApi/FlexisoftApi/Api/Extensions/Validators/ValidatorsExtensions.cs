using FluentValidation;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Contracts.Dto.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Extensions.Validators
{
    public static class ValidatorsExtensions
    {
        public static IServiceCollection AddValidatorsServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<ClientCreateDto>, ClientCreateValidator>();
            //services.AddAdditionalFluentValidationRulesToSwagger(ClientCreateValidator.GetRules());
            services.AddTransient<IValidator<ClientUpdateDto>, ClientUpdateValidator>();
            //services.AddAdditionalFluentValidationRulesToSwagger(ClientUpdateValidator.GetRules());
            services.AddTransient<IValidator<EmployeeCreateDto>, EmployeeCreateValidator>();
            //services.AddAdditionalFluentValidationRulesToSwagger(EmployeeCreateValidator.GetRules());
            services.AddTransient<IValidator<EmployeeUpdateDto>, EmployeeUpdateValidator>();
            //services.AddAdditionalFluentValidationRulesToSwagger(EmployeeUpdateValidator.GetRules());
            services.AddTransient<IValidator<RoleCreateDto>, RoleCreateValidator>();
            //services.AddAdditionalFluentValidationRulesToSwagger(RoleCreateValidator.GetRules());
            services.AddTransient<IValidator<RoleUpdateDto>, RoleUpdateValidator>();
            //services.AddAdditionalFluentValidationRulesToSwagger(RoleUpdateValidator.GetRules());

            return services;
        }
    }
}
