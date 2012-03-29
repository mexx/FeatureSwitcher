using System;

namespace FeatureSwitcher
{
    /// <summary>
    /// Provides the possibility to specify the control features behaviour to be used.
    /// </summary>
    public static class ControlFeatures
    {
        /// <summary>
        /// Gets and sets the control features behaviour to be used.
        /// </summary>
        public static IControlFeatures Behavior { get; set; }

        internal static bool IsEnabled(Type feature)
        {
            return Behavior != null && Behavior.IsEnabled(feature);
        }
    }
}