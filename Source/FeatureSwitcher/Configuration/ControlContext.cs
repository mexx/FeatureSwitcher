using ContextSwitcher;
using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher.Configuration
{
    internal interface IControlFeatureInContexts<in TContext> where TContext : IContext
    {
        bool IsEnabled<TFeature>(TContext context) where TFeature : IFeature;
    }

    internal interface IControlContexts<out TContext> where TContext : IContext
    {
        void Set(ISupportContextFor<IControlFeatures, TContext> value);
        void Set(ISupportContextFor<IProvideNaming, TContext> naming);
    }

    internal class ControlContexts<TContext> : IControlContexts<TContext>, IControlFeatureInContexts<TContext> where TContext : IContext
    {
        private ISupportContextFor<IControlFeatures, TContext> _behavior;
        private ISupportContextFor<IProvideNaming, TContext> _naming;

        public bool IsEnabled<TFeature>(TContext context) where TFeature : IFeature
        {
            return ControlFeaturesFor(context).IsEnabled(NamingFor(context).For<TFeature>());
        }

        public void Set(ISupportContextFor<IControlFeatures, TContext> value)
        {
            _behavior = value;
        }

        public void Set(ISupportContextFor<IProvideNaming, TContext> naming)
        {
            _naming = naming;
        }

        private IControlFeatures ControlFeaturesFor(TContext context)
        {
            return Behavior().With(context) ?? AllFeatures.Disabled;
        }

        private IProvideNaming NamingFor(TContext context)
        {
            return Naming().With(context) ?? Use.Type.FullName;
        }

        private ISupportContextFor<IControlFeatures, TContext> Behavior()
        {
            return _behavior ?? new NoContextSupport<IControlFeatures, TContext>(AllFeatures.Disabled);
        }

        private ISupportContextFor<IProvideNaming, TContext> Naming()
        {
            return _naming ?? new NoContextSupport<IProvideNaming, TContext>(Use.Type.FullName);
        }
    }
}