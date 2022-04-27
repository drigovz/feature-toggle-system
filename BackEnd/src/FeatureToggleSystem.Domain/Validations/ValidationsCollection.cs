using FluentValidation;

namespace FeatureToggleSystem.Domain.Validations
{
    public static class ValidationsCollection
    {
        public static IRuleBuilderOptions<T, string> Name<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder.NotNull().NotEmpty().WithMessage("Name is required!");
    }
}
