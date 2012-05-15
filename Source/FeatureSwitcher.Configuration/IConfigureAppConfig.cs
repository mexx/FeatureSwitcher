namespace FeatureSwitcher.Configuration
{
    public interface IConfigureAppConfig : IConfigureFeatures
    {
        IConfigureAppConfig IgnoreConfigurationErrors();
        IConfigureAppConfig UsingConfigSectionGroup(string name);
    }
}