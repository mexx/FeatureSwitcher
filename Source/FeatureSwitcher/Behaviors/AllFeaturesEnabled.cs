using System;

namespace FeatureSwitcher.Behaviors
{
    /// <summary>
    /// Behavior by which all features are enabled or disabled.
    /// </summary>
    public class AllFeaturesEnabled : IControlFeatures
    {
        private readonly bool _enabled;

        /// <summary>
        /// Creates an instance of this behavior.
        /// </summary>
        /// <param name="enabled">Indicates whether features are enabled or disabled.</param>
        public AllFeaturesEnabled(bool enabled)
        {
            _enabled = enabled;
        }

        public bool IsEnabled(Type feature)
        {
            return _enabled;
        }
    }
}