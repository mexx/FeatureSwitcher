namespace FeatureSwitcher.Configuration
{
    public static class ByAppConfig
    {
        public static IConfigureAppConfig AppConfig(this IConfigureBehavior This)
        {
            return new ConfigureAppConfig(This);
        }

        internal static IConfigureAppConfig AppConfig(this IConfigureBehavior This, DefaultSection defaultSection, FeaturesSection featuresSection)
        {
            return new ConfigureAppConfig(This, defaultSection, featuresSection);
        }
    }
}