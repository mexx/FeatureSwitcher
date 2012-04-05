using FeatureSwitcher.Configuration.Internal;

namespace FeatureSwitcher.Configuration
{
    public static class InContexts
    {
        public static IConfigurationFor<TContext> OfType<TContext>()
            where TContext : IContext
        {
            return new ConfigurationFor<TContext>();
        }
    }
}