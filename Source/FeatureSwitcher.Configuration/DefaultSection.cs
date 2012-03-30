using System.Configuration;

namespace FeatureSwitcher.Configuration
{
    public sealed class DefaultSection : ConfigurationSection
    {
        private const string FeaturesEnabledProperty = "featuresEnabled";

        /// <summary>
        /// Indicates the default for features not listed in &lt;features&gt;.
        /// </summary>
        [ConfigurationProperty(FeaturesEnabledProperty, DefaultValue = false)]
        public bool FeaturesEnabled
        {
            get { return (bool)base[FeaturesEnabledProperty]; }
            set { base[FeaturesEnabledProperty] = value; }
        }
    }
}