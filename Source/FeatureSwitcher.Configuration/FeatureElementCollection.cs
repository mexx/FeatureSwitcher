using System.Configuration;

namespace FeatureSwitcher.Configuration
{
    [ConfigurationCollection(typeof(FeatureElement), AddItemName = ItemProperty, CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public sealed class FeatureElementCollection : ConfigurationElementCollection
    {
        private const string ItemProperty = "feature";

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
}