namespace FeatureSwitcher.Configuration
{
    /// <summary>
    /// Entry point for fluent features configuration.
    /// </summary>
    public static partial class Features
    {
        /// <summary>
        /// Gets the extension point for features configuration.
        /// </summary>
        public static IConfigureFeatures Are
        {
            get
            {
                var result = new Builder(Feature.Configuration.Default);
                Feature.Configuration.Provider = result.Build;
                return result;
            }
        }

        /// <summary>
        /// Configures all features as enabled.
        /// </summary>
        /// <param name="This">The extension point for features configuration.</param>
        /// <returns>the extension point for features configuration.</returns>
        public static IConfigureFeatures AlwaysEnabled(this IConfigureFeatures This)
        {
            return This.ConfiguredBy.Custom(OfAnyType.Enabled);
        }

        /// <summary>
        /// Configures all features as disabled.
        /// </summary>
        /// <param name="This">The extension point for features configuration.</param>
        /// <returns>the extension point for features configuration.</returns>
        public static IConfigureFeatures AlwaysDisabled(this IConfigureFeatures This)
        {
            return This.ConfiguredBy.Custom(OfAnyType.Disabled);
        }

        /// <summary>
        /// Configures all features to be named by full name of the type.
        /// </summary>
        /// <param name="This">The extension point for naming configuration.</param>
        /// <returns>the extension point for features configuration.</returns>
        public static IConfigureFeatures TypeFullName(this IConfigureNaming This)
        {
            return This.Custom(OfAnyType.NamedByTypeFullName);
        }

        /// <summary>
        /// Configures all features to be named by name of the type.
        /// </summary>
        /// <param name="This">The extension point for naming configuration.</param>
        /// <returns>the extension point for features configuration.</returns>
        public static IConfigureFeatures TypeName(this IConfigureNaming This)
        {
            return This.Custom(OfAnyType.NamedByTypeName);
        }

        /// <summary>
        /// Configures all features to be handled by <seealso cref="Feature.Configuration.Default"/>.
        /// </summary>
        /// <param name="This">The extension point for features configuration.</param>
        /// <returns>the extension point for features configuration.</returns>
        public static IConfigureFeatures HandledByDefault(this IConfigureFeatures This)
        {
            return This.
                ConfiguredBy.Custom(null).And.
                NamedBy.Custom(null);
        }
    }
}