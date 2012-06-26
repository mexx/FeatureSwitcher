namespace FeatureSwitcher.Configuration
{
    public interface IConfigureNaming
    {
        IConfigureFeatures Custom(params IProvideNaming[] naming);
    }
}