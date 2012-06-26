namespace FeatureSwitcher.Configuration
{
    /// <summary>
    /// Can control which features are enabled or disabled.
    /// </summary>
    public interface IProvideBehavior
    {
        /// <summary>
        /// Can control whether the feature is enabled or disabled.
        /// </summary>
        /// <param name="feature">The name of the feature.</param>
        /// <returns><c>true</c> if feature is enabled, <c>false</c> if not, <c>null</c> if the state of the feature can't be determined.</returns>
        bool? IsEnabled(string feature);
    }
}