using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Api;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Logs;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Extensions.Validators;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Contracts;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiConfiguration>(_configuration);

            services.AddLogServices(_environment);

            services
                .AddControllers()
                .BuildControllersConfiguration();

            services.AddHttpContextAccessor();

            services.AddDataProtection()
             .SetApplicationName(_configuration["ApplicationName"])
             .PersistKeysToFileSystem(new DirectoryInfo(_configuration["DataProtectionSecurityPath"]));

            services.AddValidatorsServices();

            services.AddApplicationServices();


            services.AddAplCreationContextServices(_configuration);

            services.AddCoreConfiguration(_configuration, _environment);



            ConfigureRepositories(services);
        }

        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpsRedirection();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseLogServices();

            app.UseCustomErrorHandler();

            app.UseStaticFiles();

            app.UseStatusCodePages();

            app.UseCoreConfiguration(_configuration, apiVersionDescriptionProvider);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public virtual void ConfigureRepositories(IServiceCollection services)
        {

            var apiConfiguration = _configuration.Get<ApiConfiguration>();

            if (apiConfiguration.EnableMock)
            {
                services.AddApplicationMockedRespositories();
            }
            else
            {
                services.AddApplicationRespositories((serviceProvider, configuration) =>
                {
                    //var aplCreationContext = serviceProvider.GetService<IAplCreationContexte>();
                    //configuration.DbConnectionString = aplCreationContext.DbConnectionString;
                });
            }
        }
    }
}
