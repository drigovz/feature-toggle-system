using FeatureToggle.Domain.Entities;
using FeatureToggle.Domain.Interfaces.Repository;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace FeatureToggle.Infra.Data.Repository;

public class BaseRepository<E, T> : IBaseRepository<E, int> where E : BaseEntity
{
    private Container _container;
    private static readonly JsonSerializer _serializer = new();

    public BaseRepository(CosmosClient dbClient, string databaseName, string containerName)
    {
        _container = dbClient.GetContainer(databaseName, containerName);
    }

    public async Task<IEnumerable<E>> GetAsync()
    {
        string query = $"select * from {typeof(E)}";
        var queryResult = _container.GetItemQueryIterator<E>(new QueryDefinition(query));
        var results = new List<E>();
        while (queryResult.HasMoreResults)
        {
            var response = await queryResult.ReadNextAsync();
            results.AddRange(response.ToList());
        }
        
        return results;
    }

    public async Task<E> GetByIdAsync(int id)
    {
        return await _container.DeleteItemAsync<E>($"{id}", new PartitionKey($"{id}"));
    }

    public async Task<E> AddAsync(E entity)
    {
        return await _container.CreateItemAsync<E>(entity, new PartitionKey(entity.Id));
    }

    public async Task<E> UpdateAsync(E entity)
    {
        var result = await GetByIdAsync(entity.Id);
        if (result!=null)
        {
            return await _container.ReplaceItemAsync<E>(result, $"{entity.Id}", new PartitionKey($"{result.Id}"));
        }

        return null;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            await _container.DeleteItemAsync<E>($"{id}", new PartitionKey($"{id}"));
            return true;
        }
        else
            return false;
        
        return true;
    }
}