using FeatureToggle.Domain.Entities;
using FeatureToggle.Domain.Interfaces.Repository;

namespace FeatureToggle.Domain.Interfaces;

public interface IFeatureGroupRepository: IBaseRepository<FeatureGroup, int>
{ }