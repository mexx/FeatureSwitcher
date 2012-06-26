namespace FeatureSwitcher.Configuration
{
    public class AppConfigDefault : IProvideBehavior
    {
        private readonly DefaultSection _defaultSection;

        public AppConfigDefault(DefaultSection defaultSection)
        {
            _defaultSection = defaultSection;
        }

        bool? IProvideBehavior.IsEnabled(string feature)
        {
            if (_defaultSection == null)
                return null;

            return _defaultSection.FeaturesEnabled;
        }
    }
}