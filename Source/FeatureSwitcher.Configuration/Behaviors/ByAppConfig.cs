using System;
using ContextSwitcher;
using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher.Configuration
{
    public static class ByAppConfig
    {
        public static ConfigureBehaviorAppConfig<TContext> AppConfig<TContext>(this IConfigureBehavior<TContext> This) where TContext : IContext
        {
            return new ConfigureBehaviorAppConfig<TContext>(This);
        }

        internal static ConfigureBehaviorAppConfig<TContext> AppConfig<TContext>(this IConfigureBehavior<TContext> This, DefaultSection defaultSection, FeaturesSection featuresSection) where TContext : IContext
        {
            return new ConfigureBehaviorAppConfig<TContext>(This, defaultSection, featuresSection);
        }
    }

    public sealed class ConfigureBehaviorAppConfig<TContext> : IFeatureConfiguration<TContext> where TContext : IContext
    {
        private readonly IConfigureBehavior<TContext> _control;
        private readonly AppConfig _appConfig;
        private readonly IFeatureConfiguration<TContext> _configuration;

        public ConfigureBehaviorAppConfig(IConfigureBehavior<TContext> control)
            :this(control, new AppConfig())
        {
        }

        public ConfigureBehaviorAppConfig(IConfigureBehavior<TContext> control, DefaultSection defaultSection, FeaturesSection featuresSection)
            : this(control, new AppConfig(defaultSection, featuresSection))
        {
        }

        private ConfigureBehaviorAppConfig(IConfigureBehavior<TContext> control, AppConfig appConfig)
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

        public IFeatureConfiguration<TContext> And
        {
            get { return _configuration; }
        }

        public IConfigureNaming<TContext> NamedBy
        {
            get { throw new NotImplementedException(); }
        }

        public IConfigureBehavior<TContext> ConfiguredBy
        {
            get { throw new NotImplementedException(); }
        }
    }
}