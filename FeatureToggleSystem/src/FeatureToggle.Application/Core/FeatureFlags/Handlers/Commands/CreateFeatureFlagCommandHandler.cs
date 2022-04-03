using FeatureToggle.Application.Core.FeatureFlags.Commands;
using FeatureToggle.Application.Notifications;
using FeatureToggle.Domain.Entities;
using FeatureToggle.Domain.Interfaces;
using MediatR;
using System.Text.Json;

namespace FeatureToggle.Application.Core.FeatureFlags.Handlers.Commands
{
    public class CreateFeatureFlagCommandHandler : IRequestHandler<FeatureFlagCreateCommand, GenericResponse>
    {
        private readonly IFeatureFlagRepository _featureFlagRepository;
        private readonly NotificationContext _notification;

        public CreateFeatureFlagCommandHandler(IFeatureFlagRepository featureFlagRepository, NotificationContext notification)
        {
            _featureFlagRepository = featureFlagRepository;
            _notification = notification;
        }

        public async Task<GenericResponse> Handle(FeatureFlagCreateCommand request, CancellationToken cancellationToken)
        {
            var group = request.Group == null ? new FeatureGroup("Default", "Description exemple") : request.Group;

            var featureFlag = new FeatureFlag(request.Title, request.Description, group, request.Active);
            if (!featureFlag.Valid)
            {
                _notification.AddNotifications(featureFlag.ValidationResult);

                return new GenericResponse { Notifications = _notification.Notifications, };
            }

            var result = await _featureFlagRepository.AddAsync(featureFlag);
            if (!featureFlag.Valid)
            {
                _notification.AddNotification("Error", JsonSerializer.Serialize(featureFlag?.ValidationResult.Errors));

                return new GenericResponse { Notifications = _notification.Notifications, };
            }

            return new GenericResponse
            {
                Result = result,
            };
        }
    }
}
