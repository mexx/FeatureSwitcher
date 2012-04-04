namespace FeatureSwitcher.Configuration
{
    public interface IConfigureNaming
    {
        IProvideFeatureNames Naming { get; set; }
    }
}