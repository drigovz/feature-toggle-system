using FeatureToggle.Domain.Entities;
using FluentValidation;

namespace FeatureToggle.Domain.Validations;

public class FeatureGroupValidator: AbstractValidator<FeatureGroup>
{
    public FeatureGroupValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.Description).Description();
    }
}