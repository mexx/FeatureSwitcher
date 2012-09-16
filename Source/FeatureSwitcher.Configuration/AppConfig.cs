namespace FeatureSwitcher.Configuration
{
    public class AppConfig
    {
        public Feature.Behavior Default
        {
            get { return AppConfigDefault.IsEnabled; }
        }

        public Feature.Behavior Features
        {
            get { return AppConfigFeatures.IsEnabled; }
        }

        private readonly DefaultSection _default;
        private readonly FeaturesSection _features;
        private readonly AppConfigSettings _settings;

        public AppConfig()
            : this(new AppConfigSettings())
        {
        }

        public AppConfig(string sectionGroupName)
            : this(new AppConfigSettings().WithSectionGroupName(sectionGroupName))
        {            
        }

        public AppConfig(bool ignoreConfigurationErrors)
            : this(new AppConfigSettings().WithIgnoreConfigurationErrors(ignoreConfigurationErrors))
        {
        }

        public AppConfig(string sectionGroupName, bool ignoreConfigurationErrors)
            : this(new AppConfigSettings().WithSectionGroupName(sectionGroupName).WithIgnoreConfigurationErrors(ignoreConfigurationErrors))
        {
        }

        public AppConfig(AppConfigSettings settings)
            : this(null, null, settings)
        {
        }

        public AppConfig(DefaultSection defaultSection, FeaturesSection featuresSection)
            : this(defaultSection, featuresSection, new AppConfigSettings())
        {
        }

        private AppConfig(DefaultSection defaultSection, FeaturesSection featuresSection, AppConfigSettings settings)
        {
            _default = defaultSection;
            _features = featuresSection;
            _settings = settings;
        }

        private DefaultSection DefaultSection
        {
            get { return _default ?? SectionGroup.GetDefaultSection(_settings.SectionGroupName, _settings.IgnoreConfigurationErrors); }
        }

        private FeaturesSection FeaturesSection
        {
            get { return _features ?? SectionGroup.GetFeaturesSection(_settings.SectionGroupName, _settings.IgnoreConfigurationErrors); }
        }

        public bool? IsEnabled(string feature)
        {
            return Features(feature).GetValueOrDefault(Default(feature).GetValueOrDefault());
        }

        private AppConfigDefault AppConfigDefault
        {
            get { return new AppConfigDefault(DefaultSection); }
        }

        private AppConfigFeatures AppConfigFeatures
        {
            get { return new AppConfigFeatures(FeaturesSection); }
        }
    }
}