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

        public IConfigureFeaturesFor<TContext> Custom(Func<TContext, IProvideNaming> naming)
        {
            FeatureConfiguration.Set(naming);
            return this;
        }

        public IConfigureFeatures Custom(IProvideNaming naming)
        {
            return Custom(ctx => naming);
        }

        public IConfigureFeaturesFor<TContext> Custom(Func<TContext, IProvideBehavior> behavior)
        {
            FeatureConfiguration.Set(behavior);
            return this;
        }

        public IConfigureFeatures Custom(IProvideBehavior behavior)
        {
            return Custom(ctx => behavior);
        }
    }
}