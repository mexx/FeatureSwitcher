namespace FeatureSwitcher.Behaviors
{
    public interface IAllFeaturesBehavior
    {
        IControlFeatures Enabled { get; }
        IControlFeatures Disabled { get; }
    }
}