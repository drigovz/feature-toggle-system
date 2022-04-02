using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace FeatureToggle.Domain.Entities;

public abstract class BaseEntity
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; protected set; }
    
    [JsonProperty(PropertyName = "createdAt")]
    private DateTime? _createdAt;
    public DateTime? CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value ?? DateTime.UtcNow;
    }
    
    [JsonProperty(PropertyName = "updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [NotMapped]
    [System.Text.Json.Serialization.JsonIgnore]
    public bool Valid { get; protected set; }

    [NotMapped]
    [System.Text.Json.Serialization.JsonIgnore]
    public ValidationResult ValidationResult { get; protected set; }

    protected bool EntityValidation<T>(T model, AbstractValidator<T> validator)
    {
        ValidationResult = validator.Validate(model);
        return Valid = ValidationResult.IsValid;
    }
}
