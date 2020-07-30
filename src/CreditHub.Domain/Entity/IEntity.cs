namespace CreditHub.Domain.Entity
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
