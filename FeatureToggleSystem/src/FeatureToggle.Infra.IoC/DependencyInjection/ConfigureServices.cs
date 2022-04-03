using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureToggle.Infra.IoC.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var handlers = AppDomain.CurrentDomain.Load("FeatureToggle.Application");
            services.AddMediatR(handlers);

            return services;
        }
    }
}
