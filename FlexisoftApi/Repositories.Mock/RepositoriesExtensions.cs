using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.DB;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.Roles;
using Microsoft.Extensions.DependencyInjection;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock
{
    public static class RepositoriesExtensions
    {
        public static IServiceCollection AddApplicationMockedRespositories(this IServiceCollection services)
        {
            services.AddSingleton(new ClientsDB());
            services.AddTransient<IClientsReader, ClientsRepository>();
            services.AddTransient<IClientsCommand, ClientsRepository>();
            services.AddSingleton(new EmployeesDB());
            services.AddTransient<IEmployeesReader, EmployeesRepository>();
            services.AddTransient<IEmployeesCommand, EmployeesRepository>();
            services.AddSingleton(new RolesDB());
            services.AddTransient<IRolesReader, RolesRepository>();
            services.AddTransient<IRolesCommand, RolesRepository>();

            return services;
        }
    }
}
