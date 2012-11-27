namespace FeatureSwitcher.Configuration
{
    public class AppConfigDefault
    {
        private readonly DefaultSection _defaultSection;

        public AppConfigDefault(DefaultSection defaultSection)
        {
            _defaultSection = defaultSection;
        }

        public bool? IsEnabled(Feature.Name feature)
        {
            if (_defaultSection == null)
                return null;

            return _defaultSection.FeaturesEnabled;
        }
    }
}