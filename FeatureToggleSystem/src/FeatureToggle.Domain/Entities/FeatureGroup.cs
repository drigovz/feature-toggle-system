using FeatureToggle.Domain.Validations;
using Newtonsoft.Json;

namespace FeatureToggle.Domain.Entities;

public class FeatureGroup : BaseEntity
{
    [JsonProperty(PropertyName = "name")]
    public string Name { get; private set; }
    
    [JsonProperty(PropertyName = "description")]
    public string Description { get; private set; }
    
    public FeatureGroup(int id, string name, string description)
    {
        Name = name;
        Description = description;
        Id = id;
        
        EntityValidation(this, new FeatureGroupValidator());
    }
    
    public FeatureGroup(string name, string description)
    {
        Name = name;
        Description = description;
        
        EntityValidation(this, new FeatureGroupValidator());
    }

    public FeatureGroup Update(string name, string description)
    {
        Name = name;
        Description = description;

        EntityValidation(this, new FeatureGroupValidator());
        
        return this;
    }
}