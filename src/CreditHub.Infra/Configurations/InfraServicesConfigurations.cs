using CreditHub.Infra.Configurations.PostgreSql;
using CreditHub.Infra.Configurations.Redis;
using CreditHub.Infra.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CreditHub.Infra.Configurations
{
    public static class InfraServicesConfiguration
    {
        public static void RegisterInfraServices(this IServiceCollection services, IConnectionSettings connectionSettings, IConfiguration configuration)
        {            
            services.RegisterDatabase(connectionSettings);

            services.RegisterRepositories();

            services.RegisterRedis(connectionSettings);
        }
    }
}