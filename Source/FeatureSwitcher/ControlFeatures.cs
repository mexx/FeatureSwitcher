using System;

namespace FeatureSwitcher
{
    /// <summary>
    /// Provides the possibility to specify the control features behaviour to be used.
    /// </summary>
    public static class ControlFeatures
    {
        private static IControlFeatures _behavior;
        private static IProvideFeatureNames _name;

        static ControlFeatures()
        {
            Behavior = null;
            Name = null;
        }

        /// <summary>
        /// Gets and sets the control features behaviour to be used.
        /// </summary>
        public static IControlFeatures Behavior
        {
            get { return _behavior; }
            set { _behavior = value ?? Use.AllFeatures.Disabled; }
        }

        /// <summary>
        /// Gets and sets the provider for feature names to be used.
        /// </summary>
        public static IProvideFeatureNames Name
        {
            get { return _name; }
            set { _name = value ?? Use.Type.FullName; }
        }

        internal static bool IsEnabled(Type feature)
        {
            return Behavior.IsEnabled(Name.For(feature));
        }
    }
}