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
            get { return ControlFeatures.IsEnabled(typeof (T)); }
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
        public static bool IsEnabled(this IFeature This)
        {
            return ControlFeatures.IsEnabled(This.GetType());
        }
        
        /// <summary>
        /// Gets whether the feature is disabled
        /// </summary>
        public static bool IsDisabled(this IFeature This)
        {
            return !IsEnabled(This);
        }
    }
}