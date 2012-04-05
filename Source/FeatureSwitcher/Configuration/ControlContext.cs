using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher.Configuration
{
    internal interface IControlFeatureInContexts<in TContext> where TContext : IContext
    {
        bool IsEnabled<TFeature>(TContext context) where TFeature : IFeature;
    }

    internal interface IControlContexts<out TContext> where TContext : IContext
    {
        void Set(IInContextOf<TContext, IControlFeatures> value);
        void Set(IInContextOf<TContext, IProvideNaming> naming);
    }

    internal class ControlContexts<TContext> : IControlContexts<TContext>, IControlFeatureInContexts<TContext> where TContext : IContext
    {
        private IInContextOf<TContext, IControlFeatures> _behavior;
        private IInContextOf<TContext, IProvideNaming> _naming;

        public bool IsEnabled<TFeature>(TContext context) where TFeature : IFeature
        {
            return ControlFeaturesFor(context).IsEnabled(NamingFor(context).For<TFeature>());
        }

        public void Set(IInContextOf<TContext, IControlFeatures> value)
        {
            _behavior = value;
        }

        public void Set(IInContextOf<TContext, IProvideNaming> naming)
        {
            _naming = naming;
        }

        private IControlFeatures ControlFeaturesFor(TContext context)
        {
            var result = _behavior != null ? _behavior.With(context) : null;
            return result ?? AllFeatures.Disabled;
        }

        private IProvideNaming NamingFor(TContext context)
        {
            var result = _naming != null ? _naming.With(context) : null;
            return result ?? Use.Type.FullName;
        }
    }
}