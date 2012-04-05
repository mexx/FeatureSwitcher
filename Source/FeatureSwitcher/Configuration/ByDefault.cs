using FeatureSwitcher.Configuration.Internal;

namespace FeatureSwitcher.Configuration
{
    public static class ByDefault
    {
        public static readonly IConfigureFeaturesFor<IContext> FeaturesAre = new FeatureConfigurationFor<IContext>();
    }
}