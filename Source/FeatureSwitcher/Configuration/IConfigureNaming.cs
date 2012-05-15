namespace FeatureSwitcher.Configuration
{
    public interface IConfigureNaming
    {
        IConfigureFeatures Custom(IProvideNaming naming);
    }
}