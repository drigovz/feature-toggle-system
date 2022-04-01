using FeatureToggle.Domain.Entities;
using FluentValidation;

namespace FeatureToggle.Domain.Validations;

public class FeatureFlagValidator: AbstractValidator<FeatureFlag>
{
    public FeatureFlagValidator()
    {
        RuleFor(x => x.Title).Title();
        RuleFor(x => x.Description).Description();
        RuleFor(x => x.Active).NotNull().NotEmpty();
    }
}