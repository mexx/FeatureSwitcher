using System;
using FeatureSwitcher.Behaviors;
using FeatureSwitcher.Behaviors.Internal;
using FeatureSwitcher.NamingConventions;
using FeatureSwitcher.NamingConventions.Internal;

namespace FeatureSwitcher.Configuration
{
    public static class Use
    {
        static Use()
        {
            AllFeatures = new AllFeaturesBehavior();
            SettingsFrom = null;
            Type = new ProvideFeatureNameForTypes();
        }

        [Obsolete("may be")]
        public static IAllFeaturesBehavior AllFeatures { get; private set; }

        [Obsolete("may be")]
        public static IConfigurableBehavior SettingsFrom { get; private set; }

        [Obsolete("may be")]
        public static IProvideFeatureNameForTypes Type { get; private set; }
    }
}