using Bootstrap.Extensions;
using FeatureSwitcher.Configuration;

namespace Bootstrap.FeatureSwitcher
{
    public class FeatureToggleExtension : IBootstrapperExtension
    {
        private readonly IProvideBehavior _behavior;

        public FeatureToggleExtension(IProvideBehavior behavior)
        {
            _behavior = behavior;
        }

        public void Run()
        {
            ByDefault.FeaturesAre.ConfiguredBy.Custom(_behavior ?? Bootstrapper.ContainerExtension.Resolve<IProvideBehavior>());
        }

        public void Reset()
        {
            ByDefault.FeaturesAre.ConfiguredBy.Custom((IProvideBehavior) null);
        }
    }
}