using System;
using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    /// <summary>
    /// Provides the possibility to specify the control features behaviour to be used.
    /// </summary>    
    [Obsolete("may be")]
    public static class ControlFeatures
    {
        /// <summary>
        /// Gets and sets the control features behaviour to be used.
        /// </summary>
        public static IControlFeatures Behavior
        {
            get { return Control.For(Context.Default).Behavior; }
            set { Control.For(Context.Default).Behavior = value; }
        }

        /// <summary>
        /// Gets and sets the provider for feature names to be used.
        /// </summary>
        public static IProvideFeatureNames Name
        {
            get { return Control.For(Context.Default).Naming; }
            set { Control.For(Context.Default).Naming = value; }
        }

        internal static bool IsEnabled(Type feature)
        {
            return Behavior.IsEnabled(Name.For(feature));
        }
    }
}