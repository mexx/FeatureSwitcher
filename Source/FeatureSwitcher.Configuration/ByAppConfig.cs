using FeatureSwitcher.Configuration.Internal;

namespace FeatureSwitcher.Configuration
{
    public static class ByAppConfig
    {
        public static IConfigureAppConfigFor<TContext> AppConfig<TContext>(this IConfigureIn<TContext, IProvideBehavior> This)
            where TContext : IContext
        {
            return new ConfigureAppConfigFor<TContext>(This);
        }

        internal static IConfigureAppConfigFor<TContext> AppConfig<TContext>(this IConfigureIn<TContext, IProvideBehavior> This, DefaultSection defaultSection, FeaturesSection featuresSection)
            where TContext : IContext
        {
            return new ConfigureAppConfigFor<TContext>(This, defaultSection, featuresSection);
        }
    }
}