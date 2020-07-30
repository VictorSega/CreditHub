using Microsoft.Extensions.Configuration;

namespace CreditHub.Infra.Settings
{
    public class ConnectionSettings : IConnectionSettings
    {
        public string PostgreSql { get; set; }
        public string Redis { get; set; }

        public static ConnectionSettings getInstance(IConfiguration configuration)
        {
            var connectionSettings = new ConnectionSettings();
            configuration.GetSection("ConnectionStrings").Bind(connectionSettings);
            return connectionSettings;
        }
    }    
}