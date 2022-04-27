using FeatureToggleSystem.Domain.Entities;
using FluentValidation;

namespace FeatureToggleSystem.Domain.Validations
{
    public class FeatureFlagValidation : AbstractValidator<FeatureFlag>
    {
        public FeatureFlagValidation()
        {
            RuleFor(x => x.Name).Name();
            RuleFor(x => x.Description).NotNull().NotEmpty();
        }
    }
}
