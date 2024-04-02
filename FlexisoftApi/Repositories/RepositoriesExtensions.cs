using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Configuration;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Employees;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Roles;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Roles;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories
{
    public static class RepositoriesExtensions
    {
        public static IServiceCollection AddApplicationRespositories(this IServiceCollection services, Action<IServiceProvider, RepositoriesConfiguration> configuration)
        {
            var repositoriesConfiguration = new RepositoriesConfiguration();
            configuration?.Invoke(services.BuildServiceProvider(), repositoriesConfiguration);

            //services.AddSqlServerConnection<ClientsRepository>((configuration) =>
            //{
            //    configuration.ConnectionString = repositoriesConfiguration.DbConnectionString;
            //    configuration.LogSettings.EnableLogOnError = true;
            //    configuration.LogSettings.EnablePostRequestLog = true;
            //});

            //services.AddSqlServerConnection<EmployeesRepository>((configuration) =>
            //{
            //    configuration.ConnectionString = repositoriesConfiguration.DbConnectionString;
            //    configuration.LogSettings.EnableLogOnError = true;
            //    configuration.LogSettings.EnablePostRequestLog = true;
            //});

            //services.AddSqlServerConnection<RolesRepository>((configuration) =>
            //{
            //    configuration.ConnectionString = repositoriesConfiguration.DbConnectionString;
            //    configuration.LogSettings.EnableLogOnError = true;
            //    configuration.LogSettings.EnablePostRequestLog = true;
            //});

            services.AddTransient<IClientsReader, ClientsRepository>();
            services.AddTransient<IClientsCommand, ClientsRepository>();
            services.AddTransient<IEmployeesReader, EmployeesRepository>();
            services.AddTransient<IEmployeesCommand, EmployeesRepository>();
            services.AddTransient<IRolesReader, RolesRepository>();
            services.AddTransient<IRolesCommand, RolesRepository>();

            return services;
        }
    }
}
