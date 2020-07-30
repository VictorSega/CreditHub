using System;
using CreditHub.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using CreditHub.Infra.Settings;

namespace Tesseract.Infra.Data
{
    public class CreditHubDbContextFactory : IDesignTimeDbContextFactory<CreditHubDbContext>
    {
        public CreditHubDbContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddEnvironmentVariables(prefix: "CreditHub_")
                .Build();

            IConnectionSettings connectionSettings = ConnectionSettings.getInstance(configurationBuilder);

            if (string.IsNullOrEmpty(connectionSettings.PostgreSql))
                throw new ArgumentNullException(nameof(connectionSettings.PostgreSql));

            var optionsBuilder = new DbContextOptionsBuilder<CreditHubDbContext>();
            optionsBuilder.UseNpgsql(connectionSettings.PostgreSql);

            return new CreditHubDbContext(optionsBuilder.Options);
        }
    }
}