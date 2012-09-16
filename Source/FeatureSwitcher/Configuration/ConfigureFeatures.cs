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

        IConfigureFeatures IConfigureNaming.Custom(params Feature.NameOf[] nameOfs)
        {
            ProvideState.ConfiguredNamings = nameOfs;
            return this;
        }

        IConfigureFeatures IConfigureBehavior.Custom(params Feature.Behavior[] behaviors)
        {
            ProvideState.ConfiguredBehaviors = behaviors;
            return this;
        }
    }
}