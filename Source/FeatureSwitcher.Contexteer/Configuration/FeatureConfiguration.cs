using Contexteer;
using Contexteer.Configuration;

namespace FeatureSwitcher.Configuration
{
    public static class FeatureConfiguration
    {
        public static IConfigureFeaturesFor<TContext> FeaturesAre<TContext>(this ConfigurationOf<TContext> This)
            where TContext : IContext
        {
            var result = new FeatureConfigurationFor<TContext>();
            This.Set(typeof (FeatureConfiguration), result);
            return result;
        }

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