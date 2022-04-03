using FeatureToggle.Application.Core.FeatureFlags.Commands;
using FeatureToggle.Domain.Validations;
using FluentValidation;

namespace FeatureToggle.Application.Core.FeatureFlags.Validators
{
    public class FeatureFlagCreateCommandValidator : AbstractValidator<FeatureFlagCreateCommand>
    {
        public FeatureFlagCreateCommandValidator()
        {
            RuleFor(x => x.Title).Title();
            RuleFor(x => x.Description).Description();
            RuleFor(x => x.Active).NotNull().NotEmpty();
        }
    }
}
