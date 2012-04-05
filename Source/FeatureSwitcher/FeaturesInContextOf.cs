namespace FeatureSwitcher
{
    public sealed class FeaturesInContextOf<T>
        where T : IContext
    {
        private readonly T _context;

        public FeaturesInContextOf(T context)
        {
            _context = context;
        }

        public FeatureInContextOf<T, TResult> Feature<TResult>(TResult feature)
            where TResult : IFeature
        {
            return Feature<TResult>();
        }

        public FeatureInContextOf<T, TResult> Feature<TResult>()
            where TResult : IFeature
        {
            return new FeatureInContextOf<T, TResult>(_context);
        }

        public bool FeatureIsEnabled<TFeature>(TFeature feature)
            where TFeature : IFeature
        {
            return Feature(feature).IsEnabled;
        }

        public bool FeatureIsDisabled<TFeature>(TFeature feature)
            where TFeature : IFeature
        {
            return Feature(feature).IsDisabled;
        }
    }
}