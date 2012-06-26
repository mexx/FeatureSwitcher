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

        IConfigureFeatures IConfigureNaming.Custom(params IProvideNaming[] naming)
        {
            ProvideState.ConfiguredNamings = naming;
            return this;
        }

        IConfigureFeatures IConfigureBehavior.Custom(params IProvideBehavior[] behavior)
        {
            ProvideState.ConfiguredBehaviors = behavior;
            return this;
        }
    }
}