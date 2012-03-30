using System;
using System.Configuration;
using FeatureSwitcher.Configuration;

// ReSharper disable CheckNamespace
namespace FeatureSwitcher.Behaviors
// ReSharper restore CheckNamespace
{
    public class WithAppConfig : IControlFeatures
    {
        private readonly Section _configuration;
        private readonly bool _ignoreConfigurationErrors;

        public WithAppConfig()
            : this(null, false)
        {
        }

        public WithAppConfig(bool ignoreConfigurationErrors)
            : this(null, ignoreConfigurationErrors)
        {
        }

        internal WithAppConfig(Section configuration)
            : this(configuration, false)
        {
        }

        internal WithAppConfig(Section configuration, bool ignoreConfigurationErrors)
        {
            _configuration = configuration;
            _ignoreConfigurationErrors = ignoreConfigurationErrors;
        }

        private Section Configuration
        {
            get { return _configuration ?? ConfigurationManagerSection; }
        }

        private Section ConfigurationManagerSection
        {
            get
            {
                Section configuration = null;
                try
                {
                    configuration = ConfigurationManager.GetSection("featureSwitcher") as Section;
                }
                catch (ConfigurationErrorsException)
                {
                    if (!_ignoreConfigurationErrors)
                        throw;
                }
                return configuration ?? new Section();
            }
        }

        public bool IsEnabled(Type feature)
        {
            var featureElement = Configuration.Features[feature.FullName];

            return featureElement != null ? featureElement.Enabled : Configuration.EnabledByDefault;
        }
    }
}