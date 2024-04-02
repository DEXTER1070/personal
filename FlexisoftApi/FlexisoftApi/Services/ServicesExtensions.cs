using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Roles;
using Microsoft.Extensions.DependencyInjection;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IClientsService, ClientsService>();
            services.AddTransient<IEmployeesService, EmployeesService>();
            services.AddTransient<IRolesService, RolesService>();


            return services;
        }
    }
}
