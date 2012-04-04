namespace FeatureSwitcher
{
    /// <summary>
    /// Controls which features are enabled or disabled.
    /// </summary>
    public interface IControlFeatures
    {
        /// <summary>
        /// Controls whether the feature is enabled or disabled.
        /// </summary>
        /// <param name="feature">The name of the feature.</param>
        /// <returns><c>true</c> if feature is enabled, <c>false</c> otherwise.</returns>
        bool IsEnabled(string feature);
    }
}