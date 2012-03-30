using System;
using FeatureSwitcher.Configuration;

// ReSharper disable CheckNamespace
namespace FeatureSwitcher.Behaviors
// ReSharper restore CheckNamespace
{
    public class WithAppConfig : IControlFeatures
    {
        const string FeatureSwitcherConfigurationGroupName = "featureSwitcher";

        private readonly DefaultSection _default;
        private readonly FeaturesSection _features;
        private readonly bool _ignoreConfigurationErrors;

        public WithAppConfig()
            : this(null, null, false)
        {
        }

        public WithAppConfig(bool ignoreConfigurationErrors)
            : this(null, null, ignoreConfigurationErrors)
        {
        }

        internal WithAppConfig(DefaultSection defaultSection, FeaturesSection featuresSection)
            : this(defaultSection, featuresSection, false)
        {
        }

        internal WithAppConfig(DefaultSection defaultSection, FeaturesSection featuresSection, bool ignoreConfigurationErrors)
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
                return (T)System.Configuration.ConfigurationManager.GetSection(string.Format("{0}/{1}", FeatureSwitcherConfigurationGroupName, sectionName)) ?? new T();
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