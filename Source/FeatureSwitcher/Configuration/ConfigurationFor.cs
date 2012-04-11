namespace FeatureSwitcher.Configuration
{
    internal class ConfigurationFor<TContext> : IConfigurationFor<TContext>
        where TContext : IContext
    {
        public IConfigureFeaturesFor<TContext> FeaturesAre
        {
            get { return new FeatureConfigurationFor<TContext>(); }
        }
    }
}