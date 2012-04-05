using ContextSwitcher;

namespace FeatureSwitcher
{
    public static class InContext
    {
        public static FeatureContext<TContext> Of<TContext>(TContext context) where TContext : IContext
        {
            return new FeatureContext<TContext>(context);
        }
    }

    public sealed class FeatureContext<T> where T : IContext
    {
        private readonly T _context;

        public FeatureContext(T context)
        {
            _context = context;
        }

        public bool FeatureIsEnabled<TFeature>(TFeature feature) where TFeature : IFeature
        {
            return Feature(feature).IsEnabled;
        }

        public FeatureInContext<TFeature, T> Feature<TFeature>(TFeature feature) where TFeature : IFeature
        {
            return Feature<TFeature>();
        }

        public FeatureInContext<TFeature, T> Feature<TFeature>() where TFeature : IFeature
        {
            return new FeatureInContext<TFeature, T>(_context);
        }
    }
}