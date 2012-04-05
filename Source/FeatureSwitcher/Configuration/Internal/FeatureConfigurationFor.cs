namespace FeatureSwitcher.Configuration.Internal
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

        public IConfigureIn<TContext, IControlFeatures> ConfiguredBy
        {
            get { return new ConfigureIn<TContext, IControlFeatures>(this); }
        }
    }
}