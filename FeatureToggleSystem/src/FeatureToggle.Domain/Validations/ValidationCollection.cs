using FluentValidation;

namespace FeatureToggle.Domain.Validations;

public static class ValidationCollection
{
    public static IRuleBuilderOptions<T, string> Title<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.NotNull().NotEmpty().WithMessage("Title is required!");
    
    public static IRuleBuilderOptions<T, string> Description<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.NotNull().NotEmpty().WithMessage("Description is required!");
}