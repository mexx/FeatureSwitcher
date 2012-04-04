namespace FeatureSwitcher.Behaviors.Internal
{
    class AllFeaturesBehavior : IAllFeaturesBehavior
    {
        public IControlFeatures Enabled { get { return AllFeatures.Enabled; } }
        public IControlFeatures Disabled { get { return AllFeatures.Disabled; } }
    }
}
