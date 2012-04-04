namespace FeatureSwitcher.Configuration
{
    public interface IFeatureConfiguration
    {
        IFeatureConfiguration AlwaysEnabled();
        IFeatureConfiguration AlwaysDisabled();

        IFeatureConfiguration And { get; }

        IConfigureNaming NamedBy { get; }
        IConfigureBehavior ConfiguredBy { get; }
    }
}