using System.Threading.Tasks;
using CreditHub.Domain.Repositories;
using CreditHub.Infra.Data;

namespace CreditHub.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CreditHubDbContext creditHubDbContext;
        // private IRootAccountRepository _rootAccountRepository;
        // public IRootAccountRepository RootAccountRepository
        // {
        //     get { return _rootAccountRepository ??= new RootAccountRepository(creditHubDbContext); }
        // }

        public UnitOfWork(CreditHubDbContext creditHubDbContext)
        {
            this.creditHubDbContext = creditHubDbContext;
        }

        public Task CommitAsync()
        {
            return creditHubDbContext.SaveChangesAsync();
        }

        public ValueTask RollbackAsync()
        {
            return creditHubDbContext.DisposeAsync();
        }
    }    
}