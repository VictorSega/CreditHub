using System.Threading.Tasks;

namespace CreditHub.Domain.Repositories
{
    public interface IUnitOfWork
    {
        // IRootAccountRepository RootAccountRepository { get; }
        Task CommitAsync();
        ValueTask RollbackAsync();
    }
}