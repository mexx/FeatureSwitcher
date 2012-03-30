using FeatureSwitcher.Behaviors;
using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher
{
    public static class Use
    {
        static Use()
        {
            AllFeatures = new AllFeaturesBehavior();
            SettingsFrom = null;
        }

        public static IAllFeaturesBehavior AllFeatures { get; private set; }

        public static IConfigurableBehavior SettingsFrom { get; private set; }
    }
}