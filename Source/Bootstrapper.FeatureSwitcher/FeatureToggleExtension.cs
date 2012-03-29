using Bootstrap.Extensions;
using FeatureSwitcher;

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
            ControlFeatures.Behavior = _behavior ?? Bootstrapper.ContainerExtension.Resolve<IControlFeatures>();
        }

        public void Reset()
        {
            ControlFeatures.Behavior = null;
        }
    }
}