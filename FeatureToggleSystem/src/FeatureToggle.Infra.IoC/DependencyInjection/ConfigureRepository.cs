using FeatureToggle.Domain.Entities;
using FeatureToggle.Domain.Interfaces;
using FeatureToggle.Domain.Interfaces.Repository;
using FeatureToggle.Infra.Data.Context;
using FeatureToggle.Infra.Data.Repository;
using FeatureToggle.Infra.Data.Repository.FeatureFlag;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureToggle.Infra.IoC.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            string databaseName = configuration["CosmosDb:DatabaseName"],
                   endpoint = configuration["CosmosDb:Endpoint"],
                   key = configuration["CosmosDb:Key"];

            services.AddDbContext<AppDbContext>(x => x.UseCosmos(endpoint, key, databaseName));
            services.AddScoped(typeof(IBaseRepository<BaseEntity, int>), typeof(BaseRepository<BaseEntity, int>));
            services.AddScoped<IFeatureFlagRepository, FeatureFlagRepository>();

            return services;
        }
    }
}