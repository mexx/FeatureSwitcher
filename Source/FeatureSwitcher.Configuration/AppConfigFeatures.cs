namespace FeatureSwitcher.Configuration
{
    public class AppConfigFeatures : IProvideBehavior
    {
        private readonly FeaturesSection _features;

        public AppConfigFeatures(FeaturesSection features)
        {
            _features = features;
        }

        bool? IProvideBehavior.IsEnabled(string feature)
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