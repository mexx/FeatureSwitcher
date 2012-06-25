namespace FeatureSwitcher.Configuration
{
    public static class ByAppConfig
    {
        public static IConfigureAppConfig AppConfig(this IConfigureBehavior This)
        {
            return new ConfigureAppConfig(This);
        }
    }
}