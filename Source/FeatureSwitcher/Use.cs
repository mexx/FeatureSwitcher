using FeatureSwitcher.Behaviors;
using FeatureSwitcher.Behaviors.Internal;
using FeatureSwitcher.NamingConventions;
using FeatureSwitcher.NamingConventions.Internal;

namespace FeatureSwitcher
{
    public static class Use
    {
        static Use()
        {
            AllFeatures = new AllFeaturesBehavior();
            SettingsFrom = null;
            Type = new ProvideFeatureNameForTypes();
        }

        public static IAllFeaturesBehavior AllFeatures { get; private set; }

        public static IConfigurableBehavior SettingsFrom { get; private set; }

        public static IProvideFeatureNameForTypes Type { get; private set; }
    }
}