using FeatureToggle.Domain.Entities;
using FeatureToggle.Domain.Interfaces.Repository;
using FeatureToggle.Infra.Data.Helpers;
using FeatureToggle.Infra.Data.Repository;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureToggle.Infra.IoC.DependencyInjection;

public static class ConfigureRepository
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        DatabaseConfiguration.SetConfig(configuration);
        services.AddScoped(typeof(IBaseRepository<BaseEntity, int>), typeof(BaseRepository<BaseEntity, int>));
        
        return services;
    }
}