namespace FeatureSwitcher.Configuration
{
    public class AppConfigSettings
    {
        public AppConfigSettings()
        {
            SectionGroupName = "featureSwitcher";
        }

        public string SectionGroupName { get; private set; }

        public bool IgnoreConfigurationErrors { get; private set; }

        public AppConfigSettings WithSectionGroupName(string value)
        {
            return new AppConfigSettings
                       {
                           SectionGroupName = value, 
                           IgnoreConfigurationErrors = IgnoreConfigurationErrors
                       };
        }

        public AppConfigSettings WithIgnoreConfigurationErrors(bool value)
        {
            return new AppConfigSettings
                       {
                           SectionGroupName = SectionGroupName,
                           IgnoreConfigurationErrors = value
                       };
        }
    }
}