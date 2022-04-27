using FeatureToggleSystem.Domain.Entities;

namespace FeatureToggleSystem.Domain.Interfaces.Repository
{
    public interface IFeatureFlagRepository : IBaseRepository<FeatureFlag>
    {
        Task<bool> FlagIsActive(string featureFlagName);
    }
}
