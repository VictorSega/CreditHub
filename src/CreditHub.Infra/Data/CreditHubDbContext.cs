using Microsoft.EntityFrameworkCore;

namespace CreditHub.Infra.Data
{
    public class CreditHubDbContext : DbContext
    {
        public CreditHubDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }

        // public DbSet<RootAccount> RootAccount { get; set; }
    }
}