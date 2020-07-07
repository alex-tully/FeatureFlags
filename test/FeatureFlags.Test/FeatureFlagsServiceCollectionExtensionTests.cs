using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;

namespace FeatureFlags.Test
{
    public class FeatureFlagsServiceCollectionExtensionTests
    {
        [Fact]
        public void RegistersAllRequiredDependencies()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddScoped<IOptionsSnapshot<FeatureFlagsOptions>>(sp => new Mock<IOptionsSnapshot<FeatureFlagsOptions>>().Object);
            services.AddScoped<IConfiguration>(sp => new Mock<IConfiguration>().Object);

            // Act
            services.AddFeatureFlags();

            // Assert
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<IFeatureFlag>().Should().NotBeNull();
            serviceProvider.GetService<IConfigureOptions<FeatureFlagsOptions>>().Should().NotBeNull();
        }
    }
}
