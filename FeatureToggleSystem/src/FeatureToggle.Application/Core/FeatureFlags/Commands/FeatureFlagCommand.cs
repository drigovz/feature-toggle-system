using FeatureToggle.Domain.Entities;
using MediatR;

namespace FeatureToggle.Application.Core.FeatureFlags.Commands
{
    public class FeatureFlagCommand : IRequest<GenericResponse>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public FeatureGroup? Group { get; set; }
        public bool Active { get; set; }
    }
}
