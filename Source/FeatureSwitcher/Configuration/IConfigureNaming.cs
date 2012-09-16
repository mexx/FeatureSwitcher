namespace FeatureSwitcher.Configuration
{
    public interface IConfigureNaming
    {
        IConfigureFeatures Custom(params Feature.NameOf[] nameOfs);
    }
}