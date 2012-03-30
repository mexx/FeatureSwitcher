using System;
using System.Configuration;

namespace FeatureSwitcher.Behaviors
{
    public class WithAppConfig : IControlFeatures
    {
        private readonly Configuration.Configuration _configuration;
        private readonly bool _ignoreConfigurationErrors;

        public WithAppConfig()
            : this(null, false)
        {
        }

        public WithAppConfig(bool ignoreConfigurationErrors)
            : this(null, ignoreConfigurationErrors)
        {
        }

        internal WithAppConfig(Configuration.Configuration configuration)
            : this(configuration, false)
        {
        }

        internal WithAppConfig(Configuration.Configuration configuration, bool ignoreConfigurationErrors)
        {
            _configuration = configuration;
            _ignoreConfigurationErrors = ignoreConfigurationErrors;
        }

        private Configuration.Configuration Configuration
        {
            get { return _configuration ?? ConfigurationManagerSection; }
        }

        private Configuration.Configuration ConfigurationManagerSection
        {
            get
            {
                Configuration.Configuration configuration = null;
                try
                {
                    configuration = ConfigurationManager.GetSection("featureSwitcher") as Configuration.Configuration;
                }
                catch (ConfigurationErrorsException)
                {
                    if (!_ignoreConfigurationErrors)
                        throw;
                }
                return configuration ?? new Configuration.Configuration();
            }
        }

        public bool IsEnabled(Type feature)
        {
            var featureElement = Configuration.Features[feature.FullName];

            return featureElement != null ? featureElement.Enabled : Configuration.EnabledByDefault;
        }
    }
}