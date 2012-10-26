using Contexteer;
using Contexteer.Configuration;

namespace FeatureSwitcher.Configuration
{
    /// <summary>
    /// Extension methods for configuring context specific state of features.
    /// </summary>
    public static class FeatureConfiguration
    {
        /// <summary>
        /// Provides the extension point for features configuration in contexts of type <typeparamref name="TContext"/>.
        /// </summary>
        /// <param name="This">The extensions point for configuration of <typeparamref name="TContext"/>.</param>
        /// <typeparam name="TContext">The type of contexts to configure.</typeparam>
        /// <returns>the extension point for features configuration in contexts of type <typeparamref name="TContext"/>.</returns>
        public static IConfigureFeaturesFor<TContext> FeaturesAre<TContext>(this ConfigurationOf<TContext> This)
            where TContext : IContext
        {
            var result = new FeatureConfigurationFor<TContext>();
            This.Set(typeof (FeatureConfiguration), result);
            return result;
        }

        /// <summary>
        /// Provides the feature configuration for the specified <paramref name="context"/>.
        /// </summary>
        /// <param name="context">The context to provide configuration for.</param>
        /// <typeparam name="T">The type of context.</typeparam>
        /// <returns>the feature configuration for the specified <paramref name="context"/>.</returns>
        public static Feature.Configuration For<T>(T context)
            where T : IContext
        {
            FeatureConfigurationFor<T> configuration;
            if (In<T>.Contexts.TryGet(typeof (FeatureConfiguration), out configuration))
                return configuration.For(context);

            return IsDefault(context)
                       ? Feature.Configuration.Current
                       : For(Default.Context);
        }

        private static bool IsDefault<T>(T context)
            where T : IContext
        {
            return ReferenceEquals(Default.Context, context);
        }
    }
}