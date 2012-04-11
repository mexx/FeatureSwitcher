namespace FeatureSwitcher.Configuration
{
    public sealed class FeatureControl : IControlFeatures
    {
        internal FeatureControl(IProvideBehavior behavior, IProvideNaming naming)
        {
            Behavior = behavior;
            Naming = naming;
        }

        public IProvideBehavior Behavior { get; private set; }
        public IProvideNaming Naming { get; private set; }

        bool IControlFeatures.IsEnabled<TFeature>()
        {
            return Behavior.IsEnabled(Naming.For<TFeature>());
        }
    }
}