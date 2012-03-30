using System.Configuration;

namespace FeatureSwitcher.Configuration
{
    public sealed class SectionGroup : ConfigurationSectionGroup
    {
        internal const string DefaultProperty = "default";
        internal const string FeaturesProperty = "features";

        [ConfigurationProperty(DefaultProperty)]
        public DefaultSection DefaultSection
        {
            get { return GetOrAddSection<DefaultSection>(DefaultProperty); }
        }

        [ConfigurationProperty(FeaturesProperty)]
        public FeaturesSection FeaturesSection
        {
            get { return GetOrAddSection<FeaturesSection>(FeaturesProperty); }
        }

        private T GetOrAddSection<T>(string name) where T : ConfigurationSection, new()
        {
            var result = (T)Sections[name];
            if (result != null)
                return result;

            result = new T();
            Sections.Add(name, result);
            return result;
        }
    }
}