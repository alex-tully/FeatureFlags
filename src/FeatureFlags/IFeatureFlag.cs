namespace FeatureFlags
{
    public interface IFeatureFlag
    {
        bool IsEnabled(string name);
    }
}
