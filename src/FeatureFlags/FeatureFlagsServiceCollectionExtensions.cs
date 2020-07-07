using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FeatureFlags
{
    public static class FeatureFlagsServiceCollectionExtensions
    {
        public static IServiceCollection AddFeatureFlags(this IServiceCollection services)
        {
            services.AddSingleton<IConfigureOptions<FeatureFlagsOptions>, ConfigureFeatureFlagOptions>();
            services.AddScoped<IFeatureFlag, FeatureFlag>();

            return services;
        }
    }
}
