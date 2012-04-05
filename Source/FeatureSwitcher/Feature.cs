using ContextSwitcher;

namespace FeatureSwitcher
{
    /// <summary>
    /// Represents the feature.
    /// </summary>
    /// <typeparam name="T">The type of the feature.</typeparam>
    public static class Feature<T> where T : IFeature
    {
        /// <summary>
        /// Gets whether the feature is enabled
        /// </summary>
        public static bool IsEnabled
        {
            get { return InContext.Of(ContextSwitcher.Context.Default).Feature<T>().IsEnabled; }
        }

        /// <summary>
        /// Gets whether the feature is disabled
        /// </summary>
        public static bool IsDisabled
        {
            get { return !IsEnabled; }
        }
    }

    /// <summary>
    /// Extension methods for a feature.
    /// </summary>
    public static class Feature
    {
        /// <summary>
        /// Gets whether the feature is enabled
        /// </summary>
        public static bool IsEnabled<T>(this T This) where T : IFeature
        {
            return Feature<T>.IsEnabled;
        }

        /// <summary>
        /// Gets whether the feature is disabled
        /// </summary>
        public static bool IsDisabled<T>(this T This) where T : IFeature
        {
            return Feature<T>.IsDisabled;
        }
    }
}