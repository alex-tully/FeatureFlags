using System;
using System.Collections.Generic;

namespace FeatureFlags
{
    public class FeatureFlagsOptions : Dictionary<string, bool>
    {
        public FeatureFlagsOptions()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }
    }
}
