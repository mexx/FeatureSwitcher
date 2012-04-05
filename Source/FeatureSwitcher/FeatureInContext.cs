using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public sealed class FeatureInContext<T, TContext> where T : IFeature where TContext : IContext
    {
        private readonly TContext _context;

        internal FeatureInContext(TContext context)
        {
            _context = context;
        }

        public bool IsEnabled
        {
            get { return Control.IsEnabled<T, TContext>(_context); }
        }

        public bool IsDisabled
        {
            get { return !IsEnabled; }
        }
    }
}