using FeatureToggle.Domain.Validations;
using Newtonsoft.Json;

namespace FeatureToggle.Domain.Entities;

public class FeatureFlag : BaseEntity
{
    [JsonProperty(PropertyName = "title")]
    public string Title { get; private set; }
    
    [JsonProperty(PropertyName = "description")]
    public string Description { get; private set; }
    
    [JsonProperty(PropertyName = "group")]
    public FeatureGroup Group { get; private set; }
    
    [JsonProperty(PropertyName = "active")]
    public bool Active { get; private set; }

    public FeatureFlag(int id, string title, string description, FeatureGroup group, bool active)
    {
        Title = title;
        Description = description;
        Group = group;
        Id = id;
        
        EntityValidation(this, new FeatureFlagValidator());
    }
    
    public FeatureFlag(string title, string description, FeatureGroup group, bool active)
    {
        Title = title;
        Description = description;
        Group = group;
        Active = active;
        
        EntityValidation(this, new FeatureFlagValidator());
    }

    public FeatureFlag Update(string title, string description, FeatureGroup group, bool active)
    {
        Title = title;
        Description = description;
        Group = group;
        Active = active;

        EntityValidation(this, new FeatureFlagValidator());
        
        return this;
    }
}