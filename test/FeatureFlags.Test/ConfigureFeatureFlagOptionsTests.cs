using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace FeatureFlags.Test
{
    public class ConfigureFeatureFlagOptionsTests
    {
        public class TheConfigureMethod
        {
            [Fact]
            public void BindsConfigurationToOptions()
            {
                var builder = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>
                    {
                        ["features:test-1"] = "true",
                        ["features:test-2"] = "false",
                        ["features:test-3"] = "true"
                    });

                var configureFeatureFlagOptions = new ConfigureFeatureFlagOptions(builder.Build());
                FeatureFlagsOptions options = new FeatureFlagsOptions();

                configureFeatureFlagOptions.Configure(options);

                options.Should().HaveCount(3);
                options["test-1"].Should().BeTrue();
                options["test-2"].Should().BeFalse();
                options["test-3"].Should().BeTrue();
            }
        }
    }
}
