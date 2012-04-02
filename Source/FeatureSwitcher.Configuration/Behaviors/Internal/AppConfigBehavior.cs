using System;

// ReSharper disable CheckNamespace
namespace FeatureSwitcher.Behaviors.Internal
// ReSharper restore CheckNamespace
{
    class AppConfigBehavior : IControlFeaturesWithAppConfig
    {
        private readonly Lazy<AppConfig> _implementation = new Lazy<AppConfig>(true);

        public bool IsEnabled(string feature)
        {
            return _implementation.Value.IsEnabled(feature);
        }

        public IControlFeatures IgnoreConfigurationErrors()
        {
            return new AppConfig(true);
        }
    }
}