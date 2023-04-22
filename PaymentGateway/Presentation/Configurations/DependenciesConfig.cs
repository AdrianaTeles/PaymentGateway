using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Configurations
{
    internal static class DependenciesConfig
    {
        internal static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureRepositories(services);
            return services;
        }

       

        private static void ConfigureRepositories(IServiceCollection services)
        {
            //services.AddScoped<IProjectRepository, ProjectRepository>();
           
        }
     
    }
}
