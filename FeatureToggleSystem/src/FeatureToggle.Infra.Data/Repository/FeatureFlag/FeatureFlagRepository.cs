using FeatureToggle.Domain.Interfaces;
using FeatureToggle.Infra.Data.Context;

namespace FeatureToggle.Infra.Data.Repository.FeatureFlag
{
    public class FeatureFlagRepository : BaseRepository<Domain.Entities.FeatureFlag, int>, IFeatureFlagRepository
    {
        public FeatureFlagRepository(AppDbContext context)
            : base(context)
        { }
    }
}
