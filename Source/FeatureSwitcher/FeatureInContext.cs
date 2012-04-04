using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public sealed class FeatureInContext<T> where T : IFeature
    {
        private readonly IContext _context;

        internal FeatureInContext(IContext context)
        {
            _context = context;
        }

        public bool IsEnabled
        {
            get { return Control.IsEnabled(_context, typeof(T)); }
        }

        public bool IsDisabled
        {
            get { return !IsEnabled; }
        }
    }
}