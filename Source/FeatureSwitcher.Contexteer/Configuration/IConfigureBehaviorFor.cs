using System;
using Contexteer;

namespace FeatureSwitcher.Configuration
{
    /// <summary>
    /// Extension point for behavior in contexts of type <typeparamref name="TContext"/>.
    /// </summary>
    /// <typeparam name="TContext">The type of contexts.</typeparam>
    public interface IConfigureBehaviorFor<out TContext> : IConfigureBehavior
        where TContext : IContext
    {
        /// <summary>
        /// Sets the specified <paramref name="behaviors"/> into the configuration.
        /// </summary>
        /// <param name="behaviors">The behaviors to use.</param>
        /// <returns>the extension point for features configuration in contexts of type <typeparamref name="TContext"/>.</returns>
        IConfigureFeaturesFor<TContext> Custom(Func<TContext, Feature.Behavior[]> behaviors);
    }
}