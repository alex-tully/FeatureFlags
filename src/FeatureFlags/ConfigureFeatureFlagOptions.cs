using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FeatureFlags
{
    public class ConfigureFeatureFlagOptions : IConfigureOptions<FeatureFlagsOptions>
    {
        private const string FeaturesSectionName = "features";
        private readonly IConfiguration configuration;

        public ConfigureFeatureFlagOptions(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(FeatureFlagsOptions options)
        {
            configuration.GetSection(FeaturesSectionName).Bind(options);
        }
    }
}
