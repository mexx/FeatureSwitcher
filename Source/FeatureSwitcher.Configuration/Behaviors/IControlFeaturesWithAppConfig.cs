// ReSharper disable CheckNamespace
namespace FeatureSwitcher.Behaviors
// ReSharper restore CheckNamespace
{
    public interface IControlFeaturesWithAppConfig : IControlFeatures
    {
        IControlFeatures IgnoreConfigurationErrors();
    }
}