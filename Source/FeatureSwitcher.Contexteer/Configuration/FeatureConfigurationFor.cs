using System;
using System.Linq;
using Contexteer;

namespace FeatureSwitcher.Configuration
{
    internal class FeatureConfigurationFor<TContext> : IConfigureFeaturesFor<TContext>, IConfigureBehaviorFor<TContext>, IConfigureNamingFor<TContext>
        where TContext : IContext
    {
        private Func<TContext, Feature.NameOf[]> _nameOf;
        private Func<TContext, Feature.NameOf[]> NameOf
        {
            get { return _nameOf ?? (ctx => null); }
        }
        private Func<TContext, Feature.Behavior[]> _behavior;

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
            _nameOf = naming;
            return this;
        }

        IConfigureFeaturesFor<TContext> IConfigureBehaviorFor<TContext>.Custom(Func<TContext, Feature.Behavior[]> behaviors)
        {
            _behavior = behaviors;
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

        public Feature.Configuration For(TContext context)
        {
            return new Feature.Configuration(
                type => (NameOf(context) ?? new Feature.NameOf[0]).Where(x => x != null).Select(x => x(type)).FirstOrDefault(x => x != null),
                name => (_behavior(context) ?? new Feature.Behavior[0]).Select(x => x(name)).FirstOrDefault(x => x.HasValue),
                typeof(TContext) != typeof(Default) ? FeatureConfiguration.For(Default.Context) : Feature.Configuration.Current);
        }
    }
}