using System.Linq;
using Contexteer;
using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public static class Context
    {
        public static bool EnabledInContextOf<TFeature, TContext>(this Feature.Switch.IKnowStateOf<TFeature> This, TContext context)
            where TFeature : IFeature
            where TContext : IContext
        {
            var featureType = This.GetType().GetGenericArguments().First();
            var configuration = FeatureConfiguration.For(context);
            return Feature.Switch.For<IFeature>(featureType).With(configuration).Enabled;
        }

        public static bool DisabledInContextOf<TFeature, TContext>(this Feature.Switch.IKnowStateOf<TFeature> This, TContext context)
            where TFeature : IFeature
            where TContext : IContext
        {
            return !This.EnabledInContextOf(context);
        }
    }
}