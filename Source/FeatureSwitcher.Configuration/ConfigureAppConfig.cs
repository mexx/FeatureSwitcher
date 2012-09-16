namespace FeatureSwitcher.Configuration
{
    internal sealed class ConfigureAppConfig : IConfigureAppConfig
    {
        private readonly IConfigureBehavior _control;
        private readonly AppConfigSettings _appConfigSettings;
        private readonly IConfigureFeatures _configuration;

        internal ConfigureAppConfig(IConfigureBehavior control)
            :this(control, new AppConfigSettings())
        {
        }

        private ConfigureAppConfig(IConfigureBehavior control, AppConfigSettings appConfigSettings)
        {
            _control = control;
            _appConfigSettings = appConfigSettings;
            _configuration = _control.Custom(new AppConfig(_appConfigSettings).IsEnabled);
        }

        IConfigureAppConfig IConfigureAppConfig.IgnoreConfigurationErrors()
        {
            return new ConfigureAppConfig(_control, _appConfigSettings.WithIgnoreConfigurationErrors(true));
        }

        IConfigureAppConfig IConfigureAppConfig.UsingConfigSectionGroup(string name)
        {
            return new ConfigureAppConfig(_control, _appConfigSettings.WithSectionGroupName(name));
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