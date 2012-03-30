using System.Configuration;

namespace FeatureSwitcher.Configuration
{
    public sealed class FeaturesSection : ConfigurationSection
    {
        private const string FeaturesProperty = "";

        /// <summary>
        /// List of features.
        /// </summary>
        [ConfigurationProperty(FeaturesProperty, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(FeatureElement), AddItemName = FeatureElementCollection.ItemProperty, CollectionType = ConfigurationElementCollectionType.BasicMap)]
        public FeatureElementCollection Features
        {
            get { return (FeatureElementCollection)base[FeaturesProperty]; }
        }
    }
}