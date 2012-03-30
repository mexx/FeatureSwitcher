using System;
using System.Configuration;

namespace FeatureSwitcher.Behaviors
{
    public class WithAppConfig : IControlFeatures
    {
        private readonly Configuration.Configuration _configuration;

        public WithAppConfig() : this(null)
        {
        }

        internal WithAppConfig(Configuration.Configuration configuration)
        {
            _configuration = configuration;
        }

        private Configuration.Configuration Configuration
        {
            get
            {
                return _configuration ??
                       ConfigurationManager.GetSection("featureSwitcher") as Configuration.Configuration ??
                       new Configuration.Configuration();
            }
        }

        public bool IsEnabled(Type feature)
        {
            var featureElement = Configuration.Features[feature.FullName];

            return featureElement != null ? featureElement.Enabled : Configuration.EnabledByDefault;
        }
    }
}