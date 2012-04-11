namespace FeatureSwitcher.Configuration.Internal
{
    internal class FeatureControl : IControlFeatures
    {
        internal FeatureControl(IProvideBehavior behavior, IProvideNaming naming)
        {
            Behavior = behavior;
            Naming = naming;
        }

        public IProvideBehavior Behavior { get; private set; }
        public IProvideNaming Naming { get; private set; }

        public bool IsEnabled<TFeature>()
            where TFeature : IFeature
        {
            return Behavior.IsEnabled(Naming.For<TFeature>());
        }
    }
}