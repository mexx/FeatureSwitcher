namespace FeatureSwitcher.NamingConventions.Internal
{
    class ProvideFeatureNameForTypes : IProvideFeatureNameForTypes
    {
        public ProvideFeatureNameForTypes()
        {
            FullName = new ProvideNaming(t => t.FullName);
            Name = new ProvideNaming(t => t.Name);
        }

        public IProvideNaming FullName { get; private set; }
        public IProvideNaming Name { get; private set; }
    }
}