namespace FeatureSwitcher.Configuration
{
    public interface IConfigureBehavior
    {
        IConfigureFeatures Custom(IProvideBehavior behavior);
    }
}