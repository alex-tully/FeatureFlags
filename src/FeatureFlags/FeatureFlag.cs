using Microsoft.Extensions.Options;

namespace FeatureFlags
{
    public class FeatureFlag : IFeatureFlag
    {
        private readonly FeatureFlagsOptions _options;

        public FeatureFlag(IOptionsSnapshot<FeatureFlagsOptions> optionsSnapshot)
        {
            _options = optionsSnapshot.Value;
        }

        public bool IsEnabled(string name)
        {
            if (_options.ContainsKey(name))
            {
                return _options[name];
            }

            return false;
        }
    }
}
