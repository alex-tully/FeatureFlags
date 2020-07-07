using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace FeatureFlags.Test
{
    public class FeatureFlagTests
    {
        public class TheIsEnabledMethod
        {
            private FeatureFlag _feature;
            private Mock<IOptionsSnapshot<FeatureFlagsOptions>> _mockOptionsSnapshot;

            public TheIsEnabledMethod()
            {
                _mockOptionsSnapshot = new Mock<IOptionsSnapshot<FeatureFlagsOptions>>();

                _mockOptionsSnapshot
                    .Setup(os => os.Value)
                    .Returns(new FeatureFlagsOptions
                    { 
                        ["enabled-feature"] = true,
                        ["disabled-feature"] = false
                    });

                _feature = new FeatureFlag(_mockOptionsSnapshot.Object);
            }

            [Fact]
            public void WhenTheFeatureIsEnabledThenReturnsTrue()
            {
                _feature.IsEnabled("enabled-feature").Should().BeTrue();
            }

            [Fact]
            public void WhenTheFeatureIsNotEnabledThenReturnsFalse()
            {
                _feature.IsEnabled("disabled-feature").Should().BeFalse();
            }

            [Fact]
            public void WhenTheFeatureDoesNotExistInOptionsThenReturnsFalse()
            {
                _feature.IsEnabled("unknown").Should().BeFalse();
            }
        }
    }
}
