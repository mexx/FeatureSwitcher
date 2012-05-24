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
            return FeatureConfiguration.For(context).IsEnabled<TFeature>();
        }

        public static bool DisabledInContextOf<TFeature, TContext>(this IStateOf<TFeature> This, TContext context)
            where TFeature : IFeature
            where TContext : IContext
        {
            return !This.EnabledInContextOf(context);
        }
    }
}