namespace FeatureSwitcher.Configuration
{
    internal sealed class ConfigureAppConfig : IConfigureAppConfig
    {
        private readonly IConfigureBehavior _control;
        private readonly AppConfig _appConfig;
        private readonly IConfigureFeatures _configuration;

        internal ConfigureAppConfig(IConfigureBehavior control)
            :this(control, new AppConfig())
        {
        }

        internal ConfigureAppConfig(IConfigureBehavior control, DefaultSection defaultSection, FeaturesSection featuresSection)
            : this(control, new AppConfig(defaultSection, featuresSection))
        {
        }

        private ConfigureAppConfig(IConfigureBehavior control, AppConfig appConfig)
        {
            _control = control;
            _appConfig = appConfig;
            _configuration = _control.Custom(_appConfig);
        }

        public IConfigureAppConfig IgnoreConfigurationErrors()
        {
            return new ConfigureAppConfig(_control, _appConfig.IgnoreConfigurationErrors());
        }

        public IConfigureAppConfig UsingConfigSectionGroup(string name)
        {
            return new ConfigureAppConfig(_control, _appConfig.UseConfigSectionGroup(name));
        }

        public IConfigureFeatures And
        {
            get { return _configuration; }
        }

        public IConfigureNaming NamedBy
        {
            get { return _configuration.NamedBy; }
        }

        public IConfigureBehavior ConfiguredBy
        {
            get { return _configuration.ConfiguredBy; }
        }
    }
}