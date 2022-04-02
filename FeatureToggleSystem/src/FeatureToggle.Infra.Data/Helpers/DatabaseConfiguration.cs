using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace FeatureToggle.Infra.Data.Helpers
{
    public static class DatabaseConfiguration
    {
        private static IConfiguration _configuration;
        private static string databaseName = string.Empty,
                       containerName = string.Empty,
                       endpoint = string.Empty,
                       key = string.Empty;

        public static void SetConfig(IConfiguration configuration)
        {
            _configuration = configuration;

            databaseName = _configuration["CosmosDb:DatabaseName"];
            containerName = _configuration["CosmosDb:ContainerName"];
            endpoint = _configuration["CosmosDb:Endpoint"];
            key = _configuration["CosmosDb:Key"];
        }

        public static string GetConnectionString() => $"AccountEndpoint={endpoint}/;AccountKey={key}";

        public static CosmosClient CreateClient()
        {
            var clientOptions = new CosmosClientOptions()
            {
                HttpClientFactory = () =>
                {
                    var httpMessageHandler = new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };

                    return new HttpClient(httpMessageHandler);
                },
                ConnectionMode = ConnectionMode.Gateway
            };

            return new CosmosClient(endpoint, key, clientOptions);
        }

        public static async Task<Database?> CreateDatabase()
        {
            var databaseResponse = await CreateClient().CreateDatabaseIfNotExistsAsync(databaseName);
            if (databaseResponse != null)
                return databaseResponse.Database;
            else
                return null;
        }

        public static async Task<Container?> CreateContainer(string containerName)
        {
            var database = await CreateDatabase();
            if (database != null)
                return await database.CreateContainerIfNotExistsAsync(containerName, "/LastPath");
            else
                return null;
        }
    }
}
