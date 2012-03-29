using System;
using System.Configuration;

namespace FeatureSwitcher.Configuration
{
    public class WithAppConfig : IControlFeatures
    {
        private readonly Configuration _configuration;

        public WithAppConfig() : this(null)
        {
        }

        internal WithAppConfig(Configuration configuration)
        {
            _configuration = configuration;
        }

        private Configuration Configuration
        {
            get
            {
                return _configuration ??
                       ConfigurationManager.GetSection("featureSwitcher") as Configuration ??
                       new Configuration();
            }
        }

        public bool IsEnabled(Type feature)
        {
            return Configuration.EnabledByDefault;
        }
    }
}