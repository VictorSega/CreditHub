using System.Threading.Tasks;
using CreditHub.Domain.Entity;

namespace CreditHub.Domain.Repositories
{
    public interface IRepositoryAsync<T>
        where T : IEntity<int>
    {
        Task<T> GetByIdAsync(int entityId);
        Task<T> CreateAsync(T obj);
        Task UpdateAsync(T obj);
        void Insert(T obj);
        void Update (T obj);
    }
}