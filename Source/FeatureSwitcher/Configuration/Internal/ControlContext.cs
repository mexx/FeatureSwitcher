using System;

namespace FeatureSwitcher.Configuration.Internal
{
    internal class ControlContextsOfType<T> : IControlContextsOfType<T>, IControlFeatureInContextsOfType<T>
        where T : IContext
    {
        private InContextOf<T, IControlFeatures> _behavior;
        private InContextOf<T, IProvideNaming> _naming;

        public bool IsEnabled<TFeature>(T context)
            where TFeature : IFeature
        {
            return ControlFeaturesFor(context).IsEnabled(NamingFor(context).For<TFeature>());
        }

        public void Set<TControl>(InContextOf<T, TControl> value)
        {
            var controlType = typeof (TControl);
            if (typeof(IControlFeatures).IsAssignableFrom(controlType))            
                _behavior = value as InContextOf<T, IControlFeatures>;
            else if (typeof(IProvideNaming).IsAssignableFrom(controlType))
                _naming = value as InContextOf<T, IProvideNaming>;
            else
                throw new NotSupportedException();
        }

        private IControlFeatures ControlFeaturesFor(T context)
        {
            var result = _behavior != null ? _behavior.With(context) : null;
            return result ?? AllFeatures.Disabled;
        }

        private IProvideNaming NamingFor(T context)
        {
            var result = _naming != null ? _naming.With(context) : null;
            return result ?? ProvideNaming.ByTypeFullName;
        }
    }
}