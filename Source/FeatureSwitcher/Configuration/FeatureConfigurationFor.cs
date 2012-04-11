namespace FeatureSwitcher.Configuration
{
    internal class FeatureConfigurationFor<TContext> : IConfigureFeaturesFor<TContext>
        where TContext : IContext
    {
        public IConfigureFeaturesFor<TContext> And
        {
            get { return this; }
        }

        public IConfigureIn<TContext, IProvideNaming> NamedBy
        {
            get { return new ConfigureIn<TContext, IProvideNaming>(this); }
        }

        public IConfigureIn<TContext, IProvideBehavior> ConfiguredBy
        {
            get { return new ConfigureIn<TContext, IProvideBehavior>(this); }
        }
    }
}