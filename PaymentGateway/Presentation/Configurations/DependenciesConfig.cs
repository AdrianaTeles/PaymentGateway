using System;
using System.Configuration;
using Application.Services;
using Application.Services.Interfaces;
using Data.Repository.DatabaseContext;
using Data.Repository.Interfaces;
using Data.Repository.Repositories;
using Data.Services;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Configurations
{
    internal static class DependenciesConfig
    {
        internal static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureRepositories(services);
            ConfigureGateways(services);
            ConfigureServices(services);
            return services;
        }

       

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();   
            services.AddScoped<ICardRepository, CardRepository>();           
        }

        private static void ConfigureGateways(IServiceCollection services)
        {
            services.AddScoped<ICKOBankGateway, CKOBankGateway>();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
        }

        
    }
}
