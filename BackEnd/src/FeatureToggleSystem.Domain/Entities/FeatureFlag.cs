namespace FeatureToggleSystem.Domain.Entities
{
    public sealed class FeatureFlag : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; } = false;

        public FeatureFlag(string name, string description, bool active)
        {
            Name = name;
            Description = description;
            Active = active;
        }

        public FeatureFlag Update(string name, string description, bool active)
        {
            Name = name;
            Description = description;
            Active = active;

            return this;
        }
    }
}
