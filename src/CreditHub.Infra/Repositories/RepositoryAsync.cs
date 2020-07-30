using System.Threading.Tasks;
using CreditHub.Domain.Entity;
using CreditHub.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CreditHub.Infra.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T>
        where T : Entity<int>
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryAsync(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int entityId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public async Task<T> CreateAsync(T obj)
        {
            var entity = _dbSet.Add(obj);
            entity.State = EntityState.Added;

            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task UpdateAsync(T obj)
        {
            var entity = _dbSet.Update(obj);
            entity.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public void Insert(T obj)
        {
            var entity = _dbSet.Add(obj);
            entity.State = EntityState.Added;
        }

        public void Update(T obj)
        {
            var entity = _dbSet.Update(obj);
            entity.State = EntityState.Modified;
        }
    }    
}