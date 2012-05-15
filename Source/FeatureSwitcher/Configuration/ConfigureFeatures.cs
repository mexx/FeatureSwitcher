namespace FeatureSwitcher.Configuration
{
    internal class ConfigureFeatures : IConfigureFeatures, IConfigureNaming, IConfigureBehavior
    {
        public IConfigureFeatures And
        {
            get { return this; }
        }

        public IConfigureNaming NamedBy
        {
            get { return this; }
        }

        public IConfigureBehavior ConfiguredBy
        {
            get { return this; }
        }

        public IConfigureFeatures Custom(IProvideNaming naming)
        {
            ProvideState.ConfiguredNaming = naming;
            return this;
        }

        public IConfigureFeatures Custom(IProvideBehavior behavior)
        {
            ProvideState.ConfiguredBehavior = behavior;
            return this;
        }
    }
}