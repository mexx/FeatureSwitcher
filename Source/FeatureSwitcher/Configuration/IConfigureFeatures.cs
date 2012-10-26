namespace FeatureSwitcher.Configuration
{
    /// <summary>
    /// Extension point for features configuration.
    /// </summary>
    public interface IConfigureFeatures
    {
        /// <summary>
        /// Gets the extension point for features configuration.
        /// </summary>
        IConfigureFeatures And { get; }

        /// <summary>
        /// Gets the extension point for naming configuration.
        /// </summary>
        IConfigureNaming NamedBy { get; }

        /// <summary>
        /// Gets the extension point for behavior configuration.
        /// </summary>
        IConfigureBehavior ConfiguredBy { get; }
    }
}