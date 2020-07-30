using System.ComponentModel.DataAnnotations;

namespace CreditHub.Domain.Entity
{
    public abstract class Entity<TKey> : IEntity<TKey>
        where TKey : notnull
    {
        [Key]
        public TKey Id { get; protected set; }
    }
}
