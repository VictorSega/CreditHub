using System.Globalization;
using System.Reflection;
using CreditHub.API.Commands.Pipeline;
using CreditHub.Infra.Configurations;
using CreditHub.Infra.Settings;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CreditHub.API.Initialize
{
    public static class IocContainer
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            
            // AppSettings
            var connectionSettings = ConnectionSettings.getInstance(configuration);
            services.AddSingleton<IConnectionSettings>(connectionSettings);

            // InfraServices
            services.RegisterInfraServices(connectionSettings, configuration);           

            // Services
            // services.AddScoped<IPagtelIntegrationService, PagtelIntegrationService>();        

            // Repositories
            // services.AddScoped<IPhoneRepository, PhoneRepository>();

            // Mediator
            AssemblyScanner
                .FindValidatorsInAssembly(executingAssembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR"); // Translate AbstractValidator errors to Portuguese (Brazil)
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(executingAssembly);
        }            
    }    
}