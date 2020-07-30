using CreditHub.Infra.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace CreditHub.Infra.Configurations.Redis
{
    public static class RedisConfiguration
    {
        public static void RegisterRedis(this IServiceCollection services, IConnectionSettings connectionSettings)
        {
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = connectionSettings.Redis;
                options.InstanceName = "CreditHub:";
            });  
        }
    }    
}

