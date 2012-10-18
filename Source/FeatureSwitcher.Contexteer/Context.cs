using System.Linq;
using Contexteer;
using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public static class Context
    {
        public static bool EnabledInContextOf<TFeature, TContext>(this Feature.Switch.IKnowStateOf<TFeature> This, TContext instance)
            where TFeature : IFeature
            where TContext : IContext
        {
            return This.InContextOf(instance).Enabled;
        }

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