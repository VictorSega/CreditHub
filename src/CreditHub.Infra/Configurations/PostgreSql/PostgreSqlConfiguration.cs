using CreditHub.Domain.Repositories;
using CreditHub.Infra.Data;
using CreditHub.Infra.Repositories;
using CreditHub.Infra.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CreditHub.Infra.Configurations.PostgreSql
{
    public static class PostgreSqlConfiguration
    {
        public static void RegisterDatabase(this IServiceCollection services, IConnectionSettings connectionSettings)
        {
            services.AddDbContext<CreditHubDbContext>(options => 
            {
                options.UseNpgsql(connectionSettings.PostgreSql);
            });
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}