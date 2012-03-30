using FeatureSwitcher.Behaviors;
using FeatureSwitcher.Behaviors.Internal;

// ReSharper disable CheckNamespace
namespace FeatureSwitcher
// ReSharper restore CheckNamespace
{
    public static class AppConfigExtensions
    {
        public static IControlFeaturesWithAppConfig AppConfig(this IConfigurableBehavior This)
        {
            return new AppConfigBehavior();
        }
    }
}