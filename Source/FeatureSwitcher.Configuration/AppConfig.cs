namespace FeatureSwitcher.Configuration
{
    internal class AppConfig : IProvideBehavior
    {
        const string FeatureSwitcherConfigurationGroupName = "featureSwitcher";

        private readonly DefaultSection _default;
        private readonly FeaturesSection _features;
        private readonly bool _ignoreConfigurationErrors;
        private readonly string _sectionGroupName;

        public AppConfig()
            : this(null, null, FeatureSwitcherConfigurationGroupName, false)
        {
        }

        internal AppConfig(DefaultSection defaultSection, FeaturesSection featuresSection)
            : this(defaultSection, featuresSection, FeatureSwitcherConfigurationGroupName, false)
        {
        }

        private AppConfig(DefaultSection defaultSection, FeaturesSection featuresSection, string sectionGroupName, bool ignoreConfigurationErrors)
        {
            _default = defaultSection;
            _features = featuresSection;
            _sectionGroupName = sectionGroupName;
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
                var sectionPath = string.Format("{0}/{1}", _sectionGroupName, sectionName);
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

        bool IProvideBehavior.IsEnabled(string feature)
        {
            var featureElement = FeaturesSection.Features[feature];

            return featureElement != null ? featureElement.Enabled : DefaultSection.FeaturesEnabled;
        }

        internal AppConfig IgnoreConfigurationErrors()
        {
            return new AppConfig(_default, _features, _sectionGroupName, true);
        }

        internal AppConfig UseConfigSectionGroup(string name)
        {
            return new AppConfig(_default, _features, name, _ignoreConfigurationErrors);
        }
    }
}