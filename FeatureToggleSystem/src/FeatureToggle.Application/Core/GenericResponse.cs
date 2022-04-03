using FeatureToggle.Application.Notifications;

namespace FeatureToggle.Application.Core
{
    public class GenericResponse
    {
        public dynamic? Result { get; set; } = default;

        public IEnumerable<Notification>? Notifications { get; set; }
    }
}
