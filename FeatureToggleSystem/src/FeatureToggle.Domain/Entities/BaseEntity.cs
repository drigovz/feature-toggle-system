using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace FeatureToggle.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; protected set; }
    
    private DateTime? _createdAt;
    public DateTime? CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value ?? DateTime.UtcNow;
    }
    
    public DateTime? UpdatedAt { get; set; }

    [NotMapped]
    [JsonIgnore]
    public bool Valid { get; protected set; }

    [NotMapped]
    [JsonIgnore]
    public ValidationResult ValidationResult { get; protected set; }

    protected bool EntityValidation<T>(T model, AbstractValidator<T> validator)
    {
        ValidationResult = validator.Validate(model);
        return Valid = ValidationResult.IsValid;
    }
}
