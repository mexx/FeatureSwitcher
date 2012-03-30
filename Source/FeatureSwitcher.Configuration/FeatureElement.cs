using System.Configuration;

namespace FeatureSwitcher.Configuration
{
    public sealed class FeatureElement : ConfigurationElement
    {
        private const string NameProperty = "name";
        private const string EnabledProperty = "enabled";

        /// <summary>
        /// Gets the name of the feature.
        /// </summary>
        [ConfigurationProperty(NameProperty, IsRequired = true)]
        public string Name
        {
            get { return (string)base[NameProperty]; }
            set { base[NameProperty] = value; }
        }

        /// <summary>
        /// Gets or sets whether the feature is enabled or disabled.
        /// </summary>
        [ConfigurationProperty(EnabledProperty, DefaultValue = false)]
        public bool Enabled
        {
            get { return (bool)base[EnabledProperty]; }
            set { base[EnabledProperty] = value; }
        }
    }
}
