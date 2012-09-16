namespace FeatureSwitcher.Configuration
{
    public class AppConfigFeatures
    {
        private readonly FeaturesSection _features;

        public AppConfigFeatures(FeaturesSection features)
        {
            _features = features;
        }

        public bool? IsEnabled(string feature)
        {
            if (_features == null)
                return null;

            var featureElement = _features.Features[feature];

            if (featureElement == null)
                return null;

            return featureElement.Enabled;
        }
    }
}