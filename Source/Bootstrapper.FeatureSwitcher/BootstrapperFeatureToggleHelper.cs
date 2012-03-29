using Bootstrap.Extensions;
using FeatureSwitcher;

namespace Bootstrap.FeatureSwitcher
{
    public static class BootstrapperFeatureToggleHelper
    {
        public static BootstrapperExtensions FeatureControl(this BootstrapperExtensions extensions)
        {
            return extensions.Extension(new FeatureToggleExtension(null));
        }

        public static BootstrapperExtensions FeatureControl<T>(this BootstrapperExtensions extensions) where T:IControlFeatures, new()
        {
            return extensions.Extension(new FeatureToggleExtension(new T()));
        }
    }
}