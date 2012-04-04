namespace FeatureSwitcher.Configuration
{
    public interface IConfigureBehavior
    {
        IControlFeatures Behavior { get; set; }
    }
}