namespace FeatureSwitcher.Configuration
{
    public interface IConfigureBehavior
    {
        IConfigureFeatures Custom(params IProvideBehavior[] behavior);
    }
}