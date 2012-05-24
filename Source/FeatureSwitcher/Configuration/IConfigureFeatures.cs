namespace FeatureSwitcher.Configuration
{
    public interface IConfigureFeatures
    {
        IConfigureFeatures And { get; }

        IConfigureNaming NamedBy { get; }
        IConfigureBehavior ConfiguredBy { get; }
    }
}