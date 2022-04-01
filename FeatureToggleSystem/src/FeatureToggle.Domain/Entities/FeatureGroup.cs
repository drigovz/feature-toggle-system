using FeatureToggle.Domain.Validations;

namespace FeatureToggle.Domain.Entities;

public class FeatureGroup : BaseEntity
{
    public string Name { get; private set; }
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