namespace FeatureSwitcher.Configuration
{
    public interface IConfigureBehavior
    {
        IConfigureFeatures Custom(params Feature.Behavior[] behaviors);
    }
}