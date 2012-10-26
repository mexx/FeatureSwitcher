using System;
using Contexteer;

namespace FeatureSwitcher.Configuration
{
    /// <summary>
    /// Extension point for naming configuration in contexts of type <typeparamref name="TContext"/>.
    /// </summary>
    /// <typeparam name="TContext">The type of contexts.</typeparam>
    public interface IConfigureNamingFor<out TContext> : IConfigureNaming
        where TContext : IContext
    {
        /// <summary>
        /// Sets the specified <paramref name="namingConventions"/> into the configuration.
        /// </summary>
        /// <param name="namingConventions">The naming conventions to use.</param>
        /// <returns>the extension point for features configuration in contexts of type <typeparamref name="TContext"/>.</returns>
        IConfigureFeaturesFor<TContext> Custom(Func<TContext, Feature.NameOf[]> namingConventions);
    }
}