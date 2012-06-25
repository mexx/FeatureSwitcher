namespace FeatureSwitcher.Configuration
{
    internal class ConfigureFeatures : IConfigureFeatures, IConfigureNaming, IConfigureBehavior
    {
        IConfigureFeatures IConfigureFeatures.And
        {
            get { return this; }
        }

        IConfigureNaming IConfigureFeatures.NamedBy
        {
            get { return this; }
        }

        IConfigureBehavior IConfigureFeatures.ConfiguredBy
        {
            get { return this; }
        }

        IConfigureFeatures IConfigureNaming.Custom(IProvideNaming naming)
        {
            ProvideState.ConfiguredNaming = naming;
            return this;
        }

        IConfigureFeatures IConfigureBehavior.Custom(IProvideBehavior behavior)
        {
            ProvideState.ConfiguredBehavior = behavior;
            return this;
        }
    }
}