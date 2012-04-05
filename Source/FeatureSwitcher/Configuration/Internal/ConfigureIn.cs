namespace FeatureSwitcher.Configuration.Internal
{
    internal class ConfigureIn<TContext, TControl> : IConfigureIn<TContext, TControl>
        where TContext : IContext
    {
        private readonly FeatureConfigurationFor<TContext> _featureConfigurationFor;

        public ConfigureIn(FeatureConfigurationFor<TContext> featureConfigurationFor)
        {
            _featureConfigurationFor = featureConfigurationFor;
        }

        public IConfigureFeaturesFor<TContext> Custom(InContextOf<TContext, TControl> value)
        {
            FeatureConfiguration.SettingsFor<TContext>().Set(value);
            return _featureConfigurationFor;
        }

        public IConfigureFeaturesFor<TContext> Custom(TControl value)
        {
            return Custom(Context<TContext>.Insensitive(value));
        }
    }
}