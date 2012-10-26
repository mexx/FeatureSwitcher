using System.Linq;
using Contexteer;
using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    /// <summary>
    /// Extension methods for retrieving context specific state of features.
    /// </summary>
    public static class Context
    {
        /// <summary>
        /// Gets whether the feature is enabled in specified <typeparamref name="TContext"/> <paramref name="instance"/>.
        /// </summary>
        /// <param name="This">The object which knows the state of the feature without context.</param>
        /// <param name="instance">The instance of the context to evaluate state of the feature within.</param>
        /// <typeparam name="TFeature">The feature type.</typeparam>
        /// <typeparam name="TContext">The type of context.</typeparam>
        /// <returns><c>true</c> if feature is enabled, <c>false</c> if not</returns>
        public static bool EnabledInContextOf<TFeature, TContext>(this Feature.Switch.IKnowStateOf<TFeature> This, TContext instance)
            where TFeature : IFeature
            where TContext : IContext
        {
            return This.InContextOf(instance).Enabled;
        }

        /// <summary>
        /// Gets whether the feature is disabled in specified <typeparamref name="TContext"/> <paramref name="instance"/>.
        /// </summary>
        /// <param name="This">The object which knows the state of the feature without context.</param>
        /// <param name="instance">The instance of the context to evaluate state of the feature within.</param>
        /// <typeparam name="TFeature">The feature type.</typeparam>
        /// <typeparam name="TContext">The type of context.</typeparam>
        /// <returns><c>true</c> if feature is disabled, <c>false</c> if not</returns>
        public static bool DisabledInContextOf<TFeature, TContext>(this Feature.Switch.IKnowStateOf<TFeature> This, TContext instance)
            where TFeature : IFeature
            where TContext : IContext
        {
            return This.InContextOf(instance).Disabled;
        }

        private static Feature.Switch.IKnowStateOf<TFeature> InContextOf<TFeature, TContext>(this Feature.Switch.IKnowStateOf<TFeature> This, TContext instance)
            where TFeature : IFeature
            where TContext : IContext
        {
            var type = This.GetType().GetGenericArguments().First();
            return Feature.Switch.For<TFeature>(type).With(FeatureConfiguration.For(instance));
        }
    }
}