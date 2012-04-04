using ContextSwitcher;

namespace FeatureSwitcher.Configuration
{
    public static class ByDefault
    {
        public static readonly IFeatureConfiguration<IContext> FeaturesAre = new FeatureConfigurationFor<IContext>();
    }
}