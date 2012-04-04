using System;
using ContextSwitcher;
using FeatureSwitcher.Behaviors;
using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher.Configuration
{
    public static class ByAppConfig
    {
        public static ConfigureBehaviorAppConfig AppConfig(this IConfigureBehavior<IContext> This)
        {
            return new ConfigureBehaviorAppConfig(This);
        }

        public static ConfigureBehaviorAppConfig UsingConfigSectionGroup(this ConfigureBehaviorAppConfig This, string name)
        {
            throw new NotImplementedException();
        }

        internal static void AppConfig(this IConfigureBehavior<IContext> This, DefaultSection defaultSection, FeaturesSection featuresSection)
        {
            This.Set(new AppConfig(defaultSection, featuresSection));
        }
    }

    public sealed class ConfigureBehaviorAppConfig : IFeatureConfiguration<IContext>
    {
        private readonly IConfigureBehavior<IContext> _control;
        private readonly IControlFeaturesWithAppConfig _controlFeaturesWithAppConfig;

        public ConfigureBehaviorAppConfig(IConfigureBehavior<IContext> control)
        {
            _control = control;
            _controlFeaturesWithAppConfig = Use.SettingsFrom.AppConfig();
            _control.Set(_controlFeaturesWithAppConfig);
        }

        public ConfigureBehaviorAppConfig IgnoreConfigurationErrors()
        {
            _control.Set(_controlFeaturesWithAppConfig.IgnoreConfigurationErrors());
            return this;
        }

        public IFeatureConfiguration<IContext> And
        {
            get { throw new NotImplementedException(); }
        }

        public IConfigureNaming<IContext> NamedBy
        {
            get { throw new NotImplementedException(); }
        }

        public IConfigureBehavior<IContext> ConfiguredBy
        {
            get { throw new NotImplementedException(); }
        }
    }
}