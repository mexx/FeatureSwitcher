namespace FeatureSwitcher.Configuration.Internal
{
    internal sealed class ConfigureAppConfigFor<TContext> : IConfigureAppConfigFor<TContext>
        where TContext : IContext
    {
        private readonly IConfigureIn<TContext, IProvideBehavior> _control;
        private readonly AppConfig _appConfig;
        private readonly IConfigureFeaturesFor<TContext> _configuration;

        internal ConfigureAppConfigFor(IConfigureIn<TContext, IProvideBehavior> control)
            :this(control, new AppConfig())
        {
        }

        internal ConfigureAppConfigFor(IConfigureIn<TContext, IProvideBehavior> control, DefaultSection defaultSection, FeaturesSection featuresSection)
            : this(control, new AppConfig(defaultSection, featuresSection))
        {
        }

        private ConfigureAppConfigFor(IConfigureIn<TContext, IProvideBehavior> control, AppConfig appConfig)
        {
            _control = control;
            _appConfig = appConfig;
            _configuration = _control.Custom(_appConfig);
        }

        public IConfigureAppConfigFor<TContext> IgnoreConfigurationErrors()
        {
            return new ConfigureAppConfigFor<TContext>(_control, _appConfig.IgnoreConfigurationErrors());
        }

        public IConfigureAppConfigFor<TContext> UsingConfigSectionGroup(string name)
        {
            return new ConfigureAppConfigFor<TContext>(_control, _appConfig.UseConfigSectionGroup(name));
        }

        public IConfigureFeaturesFor<TContext> And
        {
            get { return _configuration; }
        }

        public IConfigureIn<TContext, IProvideNaming> NamedBy
        {
            get { return _configuration.NamedBy; }
        }

        public IConfigureIn<TContext, IProvideBehavior> ConfiguredBy
        {
            get { return _configuration.ConfiguredBy; }
        }
    }
}