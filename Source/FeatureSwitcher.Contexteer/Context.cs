using System.Linq;
using Contexteer;
using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public static class Context
    {
        public static bool EnabledInContextOf<TFeature, TContext>(this IStateOf<TFeature> This, TContext context)
            where TFeature : IFeature
            where TContext : IContext
        {
            var featureType = This.GetType().GetGenericArguments().First();
            var provideState = FeatureConfiguration.For(context);
            return State.Of<TFeature>(featureType).With(provideState).Enabled;
        }

        public static bool DisabledInContextOf<TFeature, TContext>(this IStateOf<TFeature> This, TContext context)
            where TFeature : IFeature
            where TContext : IContext
        {
            return !This.EnabledInContextOf(context);
        }
    }
}