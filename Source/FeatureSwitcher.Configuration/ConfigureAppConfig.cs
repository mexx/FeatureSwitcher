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

        private ConfigureAppConfig(IConfigureBehavior control, AppConfig appConfig)
        {
            _control = control;
            _appConfig = appConfig;
            _configuration = _control.Custom(_appConfig);
        }

        IConfigureAppConfig IConfigureAppConfig.IgnoreConfigurationErrors()
        {
            return new ConfigureAppConfig(_control, _appConfig.IgnoreConfigurationErrors());
        }

        IConfigureAppConfig IConfigureAppConfig.UsingConfigSectionGroup(string name)
        {
            return new ConfigureAppConfig(_control, _appConfig.UseConfigSectionGroup(name));
        }

        IConfigureFeatures IConfigureFeatures.And
        {
            get { return _configuration; }
        }

        IConfigureNaming IConfigureFeatures.NamedBy
        {
            get { return _configuration.NamedBy; }
        }

        IConfigureBehavior IConfigureFeatures.ConfiguredBy
        {
            get { return _configuration.ConfiguredBy; }
        }
    }
}