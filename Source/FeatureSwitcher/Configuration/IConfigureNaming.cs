using ContextSwitcher;

namespace FeatureSwitcher.Configuration
{
    public interface IConfigureNaming<TContext> where TContext : IContext
    {
        void Set(IProvideNaming value);
    }
}