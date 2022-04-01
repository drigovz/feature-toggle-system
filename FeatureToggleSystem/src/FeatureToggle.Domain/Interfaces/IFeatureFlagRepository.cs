using FeatureToggle.Domain.Entities;
using FeatureToggle.Domain.Interfaces.Repository;

namespace FeatureToggle.Domain.Interfaces;

public interface IFeatureFlagRepository: IBaseRepository<FeatureFlag, int>
{ }