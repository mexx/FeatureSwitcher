namespace FeatureSwitcher.Configuration
{
    /// <summary>
    /// Extension point for naming configuration.
    /// </summary>
    public interface IConfigureNaming
    {
        /// <summary>
        /// Sets the specified <paramref name="namingConventions"/> into the configuration.
        /// </summary>
        /// <param name="namingConventions">The naming conventions to use.</param>
        /// <returns>the extension point for features configuration.</returns>
        IConfigureFeatures Custom(params Feature.NamingConvention[] namingConventions);
    }
}