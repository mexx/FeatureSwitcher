namespace FeatureSwitcher.Configuration
{
    public class AppConfigDefault
    {
        private readonly DefaultSection _defaultSection;

        public AppConfigDefault(DefaultSection defaultSection)
        {
            _defaultSection = defaultSection;
        }

        public bool? IsEnabled(string feature)
        {
            if (_defaultSection == null)
                return null;

            return _defaultSection.FeaturesEnabled;
        }
    }
}