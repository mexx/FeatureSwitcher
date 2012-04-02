namespace FeatureSwitcher.NamingConventions.Internal
{
    class ProvideFeatureNameForTypes : IProvideFeatureNameForTypes
    {
        public ProvideFeatureNameForTypes()
        {
            FullName = new ProvideFeatureName(t => t.FullName);
            Name = new ProvideFeatureName(t => t.Name);
        }

        public IProvideFeatureNames FullName { get; private set; }
        public IProvideFeatureNames Name { get; private set; }
    }
}