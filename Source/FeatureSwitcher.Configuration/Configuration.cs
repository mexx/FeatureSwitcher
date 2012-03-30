using System.Configuration;

namespace FeatureSwitcher.Configuration
{
    public sealed class Configuration : ConfigurationSection
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
            get { return base["features"] as FeatureElementCollection; }
        }
    }

    [ConfigurationCollection(typeof(FeatureElement), AddItemName = "feature", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public sealed class FeatureElementCollection : ConfigurationElementCollection
    {
/*        
        public FeatureElement this[int index]
        {
            get { return BaseGet(index) as FeatureElement; }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
*/
        public new FeatureElement this[string name]
        {
            get { return BaseGet(name) as FeatureElement; }
        }

        public void Add(FeatureElement feature)
        {
            base.BaseAdd(feature);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new FeatureElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as FeatureElement).Name;
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
            get { return base["name"] as string; }
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
