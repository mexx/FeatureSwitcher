using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public sealed class FeatureInContextOf<T, TFeature>
        where T : IContext
        where TFeature : IFeature
    {
        private readonly T _context;

        internal FeatureInContextOf(T context)
        {
            _context = context;
        }

        public bool IsEnabled
        {
            get { return (FeatureConfiguration.For(_context) as IControlFeatures).IsEnabled<TFeature>(); }
        }

        public bool IsDisabled
        {
            get { return !IsEnabled; }
        }
    }
}