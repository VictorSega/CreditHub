namespace CreditHub.Infra.Settings
{
    public interface IConnectionSettings
    {
        string PostgreSql { get; }
        string Redis { get; }
    }
}