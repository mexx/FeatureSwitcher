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
    }
}