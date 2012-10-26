using Contexteer;

namespace FeatureSwitcher.Configuration
{
    /// <summary>
    /// Extension point for features configuration in contexts of type <typeparamref name="TContext"/>.
    /// </summary>
    /// <typeparam name="TContext">The type of contexts.</typeparam>
    public interface IConfigureFeaturesFor<out TContext> : IConfigureFeatures
        where TContext : IContext
    {
        /// <summary>
        /// Gets the extension point for features configuration in contexts of type <typeparamref name="TContext"/>.
        /// </summary>
        new IConfigureFeaturesFor<TContext> And { get; }

        /// <summary>
        /// Gets the extension point for naming configuration in contexts of type <typeparamref name="TContext"/>.
        /// </summary>
        new IConfigureNamingFor<TContext> NamedBy { get; }

        /// <summary>
        /// Gets the extension point for behavior configuration in contexts of type <typeparamref name="TContext"/>.
        /// </summary>
        new IConfigureBehaviorFor<TContext> ConfiguredBy { get; }
    }
}