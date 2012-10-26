namespace FeatureSwitcher.Configuration
{
    /// <summary>
    /// Extension point for behavior configuration.
    /// </summary>
    public interface IConfigureBehavior
    {
        /// <summary>
        /// Sets the specified <paramref name="behaviors"/> into the configuration.
        /// </summary>
        /// <param name="behaviors">The behaviors to use.</param>
        /// <returns>the extension point for features configuration.</returns>
        IConfigureFeatures Custom(params Feature.Behavior[] behaviors);
    }
}