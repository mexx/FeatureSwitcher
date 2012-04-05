using Bootstrap.Extensions;
using FeatureSwitcher;
using FeatureSwitcher.Configuration;

namespace Bootstrap.FeatureSwitcher
{
    public class FeatureToggleExtension : IBootstrapperExtension
    {
        private readonly IControlFeatures _behavior;

        public FeatureToggleExtension(IControlFeatures behavior)
        {
            _behavior = behavior;
        }

        public void Run()
        {
            ByDefault.FeaturesAre.ConfiguredBy.Custom(_behavior ?? Bootstrapper.ContainerExtension.Resolve<IControlFeatures>());
        }

        public void Reset()
        {
            ByDefault.FeaturesAre.ConfiguredBy.Custom((IControlFeatures) null);
        }
    }
}