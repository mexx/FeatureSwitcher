using System.Configuration;

namespace FeatureSwitcher.Configuration
{
    public sealed class Section : ConfigurationSection
    {
        /// <summary>
        /// Indicates the default for features not listed in &lt;features&gt;.
        /// </summary>
        [ConfigurationProperty("enabledByDefault", DefaultValue = false)]
        public bool EnabledByDefault
        {
            get { return (bool)base["enabledByDefault"]; }
            set { base["enabledByDefault"] = value; }
        }

        /// <summary>
        /// List of features.
        /// </summary>
        [ConfigurationProperty("features")]
        public FeatureElementCollection Features
        {
            get { return (FeatureElementCollection)base["features"]; }
        }
    }

    [ConfigurationCollection(typeof(FeatureElement), AddItemName = "feature", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public sealed class FeatureElementCollection : ConfigurationElementCollection
    {
        public new FeatureElement this[string name]
        {
            get { return (FeatureElement)BaseGet(name); }
        }

        public void Add(FeatureElement feature)
        {
            BaseAdd(feature);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new FeatureElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FeatureElement)element).Name;
        }
    }

    public sealed class FeatureElement : ConfigurationElement
    {
        /// <summary>
        /// Gets the name of the feature.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        /// <summary>
        /// Gets or sets whether the feature is enabled or disabled.
        /// </summary>
        [ConfigurationProperty("enabled", DefaultValue = false)]
        public bool Enabled
        {
            get { return (bool)base["enabled"]; }
            set { base["enabled"] = value; }
        }
    }
}
