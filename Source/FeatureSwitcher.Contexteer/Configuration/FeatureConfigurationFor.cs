using System;
using Contexteer;

namespace FeatureSwitcher.Configuration
{
    internal class FeatureConfigurationFor<TContext> : IConfigureFeaturesFor<TContext>, IConfigureBehaviorFor<TContext>, IConfigureNamingFor<TContext>
        where TContext : IContext
    {
        public IConfigureFeatures And
        {
            get { return this; }
        }

        IConfigureNamingFor<TContext> IConfigureFeaturesFor<TContext>.NamedBy
        {
            get { return this; }
        }

        IConfigureBehaviorFor<TContext> IConfigureFeaturesFor<TContext>.ConfiguredBy
        {
            get { return this; }
        }

        IConfigureFeaturesFor<TContext> IConfigureFeaturesFor<TContext>.And
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

        IConfigureFeaturesFor<TContext> IConfigureNamingFor<TContext>.Custom(Func<TContext, Feature.NameOf[]> naming)
        {
            FeatureConfiguration.Set(naming);
            return this;
        }

        IConfigureFeaturesFor<TContext> IConfigureBehaviorFor<TContext>.Custom(Func<TContext, Feature.Behavior[]> behaviors)
        {
            FeatureConfiguration.Set(behaviors);
            return this;
        }

        IConfigureFeatures IConfigureNaming.Custom(params Feature.NameOf[] nameOfs)
        {
            return (this as IConfigureNamingFor<TContext>).Custom(ctx => nameOfs);
        }

        IConfigureFeatures IConfigureBehavior.Custom(params Feature.Behavior[] behaviors)
        {
            return (this as IConfigureBehaviorFor<TContext>).Custom(ctx => behaviors);
        }
    }
}