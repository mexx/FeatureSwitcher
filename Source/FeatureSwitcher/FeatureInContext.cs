using FeatureSwitcher.Configuration.Internal;

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
            get { return FeatureConfiguration.For<T>().IsEnabled<TFeature>(_context); }
        }

        public bool IsDisabled
        {
            get { return !IsEnabled; }
        }
    }
}