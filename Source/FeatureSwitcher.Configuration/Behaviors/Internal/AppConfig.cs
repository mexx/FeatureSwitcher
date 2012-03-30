using System;
using FeatureSwitcher.Configuration;

// ReSharper disable CheckNamespace
namespace FeatureSwitcher.Behaviors.Internal
// ReSharper restore CheckNamespace
{
    class AppConfig : IControlFeatures
    {
        const string FeatureSwitcherConfigurationGroupName = "featureSwitcher";

        private readonly DefaultSection _default;
        private readonly FeaturesSection _features;
        private readonly bool _ignoreConfigurationErrors;

        public AppConfig()
            : this(null, null, false)
        {
        }

        public AppConfig(bool ignoreConfigurationErrors)
            : this(null, null, ignoreConfigurationErrors)
        {
        }

        internal AppConfig(DefaultSection defaultSection, FeaturesSection featuresSection)
            : this(defaultSection, featuresSection, false)
        {
        }

        internal AppConfig(DefaultSection defaultSection, FeaturesSection featuresSection, bool ignoreConfigurationErrors)
        {
            _default = defaultSection;
            _features = featuresSection;
            _ignoreConfigurationErrors = ignoreConfigurationErrors;
        }

        private DefaultSection DefaultSection
        {
            get { return _default ?? ConfigurationManagerSection<DefaultSection>(SectionGroup.DefaultProperty); }
        }

        private FeaturesSection FeaturesSection
        {
            get { return _features ?? ConfigurationManagerSection<FeaturesSection>(SectionGroup.FeaturesProperty); }
        }

        private T ConfigurationManagerSection<T>(string sectionName) where T : System.Configuration.ConfigurationElement, new ()
        {
            try
            {
                var sectionPath = string.Format("{0}/{1}", FeatureSwitcherConfigurationGroupName, sectionName);
                var section = (T)System.Configuration.ConfigurationManager.GetSection(sectionPath);
                if (section != null)
                    return section;
                if (_ignoreConfigurationErrors)
                    return new T();

                throw new System.Configuration.ConfigurationErrorsException(string.Format("Section {0} not found.", sectionPath));
            }
            catch (System.Configuration.ConfigurationErrorsException)
            {
                if (!_ignoreConfigurationErrors)
                    throw;
            }
            return new T();
        }

        public bool IsEnabled(Type feature)
        {
            var featureElement = FeaturesSection.Features[feature.FullName];

            return featureElement != null ? featureElement.Enabled : DefaultSection.FeaturesEnabled;
        }
    }
}