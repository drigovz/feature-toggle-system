namespace FeatureToggleSystem.Domain.Interfaces.MongoDbConfig
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
