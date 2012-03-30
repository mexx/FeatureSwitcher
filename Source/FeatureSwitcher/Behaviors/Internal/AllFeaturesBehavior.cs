namespace FeatureSwitcher.Behaviors.Internal
{
    class AllFeaturesBehavior : IAllFeaturesBehavior
    {
        public AllFeaturesBehavior()
        {
            Enabled = new AllFeatures(true);
            Disabled = new AllFeatures(false);
        }

        public IControlFeatures Enabled { get; private set; }
        public IControlFeatures Disabled { get; private set; }
    }
}
