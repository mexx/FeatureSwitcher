using System;
using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher.Configuration
{
    public static class ByAppConfig
    {
        public static ConfigureBehaviorAppConfig<TContext> AppConfig<TContext>(this IConfigureBehaviorIn<TContext> This) where TContext : IContext
        {
            return new ConfigureBehaviorAppConfig<TContext>(This);
        }

        internal static ConfigureBehaviorAppConfig<TContext> AppConfig<TContext>(this IConfigureBehaviorIn<TContext> This, DefaultSection defaultSection, FeaturesSection featuresSection) where TContext : IContext
        {
            return new ConfigureBehaviorAppConfig<TContext>(This, defaultSection, featuresSection);
        }
    }

    public sealed class ConfigureBehaviorAppConfig<TContext> : IConfigureFeaturesFor<TContext> where TContext : IContext
    {
        private readonly IConfigureBehaviorIn<TContext> _control;
        private readonly AppConfig _appConfig;
        private readonly IConfigureFeaturesFor<TContext> _configuration;

        public ConfigureBehaviorAppConfig(IConfigureBehaviorIn<TContext> control)
            :this(control, new AppConfig())
        {
        }

        public ConfigureBehaviorAppConfig(IConfigureBehaviorIn<TContext> control, DefaultSection defaultSection, FeaturesSection featuresSection)
            : this(control, new AppConfig(defaultSection, featuresSection))
        {
        }

        private ConfigureBehaviorAppConfig(IConfigureBehaviorIn<TContext> control, AppConfig appConfig)
        {
            _control = control;
            _appConfig = appConfig;
            _configuration = _control.Custom(_appConfig);
        }

        public ConfigureBehaviorAppConfig<TContext> IgnoreConfigurationErrors()
        {
            return new ConfigureBehaviorAppConfig<TContext>(_control, _appConfig.IgnoreConfigurationErrors());
        }

        public ConfigureBehaviorAppConfig<TContext> UsingConfigSectionGroup(string name)
        {
            return new ConfigureBehaviorAppConfig<TContext>(_control, _appConfig.UseConfigSectionGroup(name));
        }

        public IConfigureFeaturesFor<TContext> And
        {
            get { return _configuration; }
        }

        public IConfigureNamingIn<TContext> NamedBy
        {
            get { throw new NotImplementedException(); }
        }

        public IConfigureBehaviorIn<TContext> ConfiguredBy
        {
            get { throw new NotImplementedException(); }
        }
    }
}