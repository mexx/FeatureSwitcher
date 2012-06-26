using System;
using System.Configuration;

namespace FeatureSwitcher.Configuration
{
    public sealed class SectionGroup : ConfigurationSectionGroup
    {
        private const string DefaultProperty = "default";
        private const string FeaturesProperty = "features";

        public static DefaultSection GetDefaultSection(string groupName, bool ignoreConfigurationErrors)
        {
            return ConfigurationManagerSection<DefaultSection>(groupName, DefaultProperty, ignoreConfigurationErrors);
        }

        public static FeaturesSection GetFeaturesSection(string groupName, bool ignoreConfigurationErrors)
        {
            return ConfigurationManagerSection<FeaturesSection>(groupName, FeaturesProperty, ignoreConfigurationErrors);
        }

        private static T ConfigurationManagerSection<T>(string sectionGroupName, string sectionName, bool ignoreConfigurationErrors)
            where T : ConfigurationElement, new()
        {
            try
            {
                var sectionPath = String.Format("{0}/{1}", sectionGroupName, sectionName);
                var section = (T) ConfigurationManager.GetSection(sectionPath);
                if (section != null)
                    return section;
                if (!ignoreConfigurationErrors)
                    throw new ConfigurationErrorsException(String.Format("Section {0} not found.", sectionPath));
            }
            catch (ConfigurationErrorsException)
            {
                if (!ignoreConfigurationErrors)
                    throw;
            }
            return new T();
        }

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