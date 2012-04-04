using System;
using FeatureSwitcher.Behaviors;
using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher.Configuration
{
    public static class ByAppConfig
    {
        public static ConfigureBehaviorAppConfig AppConfig(this IConfigureBehavior This)
        {
            return new ConfigureBehaviorAppConfig(This);
        }

        public static ConfigureBehaviorAppConfig UsingConfigSectionGroup(this ConfigureBehaviorAppConfig This, string name)
        {
            throw new NotImplementedException();
        }

        internal static void AppConfig(this IConfigureBehavior This, DefaultSection defaultSection, FeaturesSection featuresSection)
        {
            This.Behavior = new AppConfig(defaultSection, featuresSection);
        }
    }

    public sealed class ConfigureBehaviorAppConfig : IFeatureConfiguration
    {
        private readonly IConfigureBehavior _control;
        private readonly IControlFeaturesWithAppConfig _controlFeaturesWithAppConfig;

        public ConfigureBehaviorAppConfig(IConfigureBehavior control)
        {
            _control = control;
            _controlFeaturesWithAppConfig = Use.SettingsFrom.AppConfig();
            _control.Behavior = _controlFeaturesWithAppConfig;
        }

        public ConfigureBehaviorAppConfig IgnoreConfigurationErrors()
        {
            _control.Behavior = _controlFeaturesWithAppConfig.IgnoreConfigurationErrors();
            return this;
        }

        public IFeatureConfiguration AlwaysEnabled()
        {
            throw new NotImplementedException();
        }

        public IFeatureConfiguration AlwaysDisabled()
        {
            throw new NotImplementedException();
        }

        public IFeatureConfiguration And
        {
            get { throw new NotImplementedException(); }
        }

        public IConfigureNaming NamedBy
        {
            get { throw new NotImplementedException(); }
        }

        public IConfigureBehavior ConfiguredBy
        {
            get { throw new NotImplementedException(); }
        }
    }
}