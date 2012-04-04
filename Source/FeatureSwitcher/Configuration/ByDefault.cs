namespace FeatureSwitcher.Configuration
{
    public static class ByDefault
    {
        public static readonly IFeatureConfiguration FeaturesAre = new FeatureConfigurationFor(Context.Default);
    }
}