using System.Configuration;

namespace FeatureSwitcher.Configuration
{
    public class Configuration : ConfigurationSection
    {
        [ConfigurationProperty("enabledByDefault", DefaultValue = false, IsRequired = false)]
        public bool EnabledByDefault
        {
            get { return (bool)base["enabledByDefault"]; }
            set { base["enabledByDefault"] = value; }
        }
    }
}
