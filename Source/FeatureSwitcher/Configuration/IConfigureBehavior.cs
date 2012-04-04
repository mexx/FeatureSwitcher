using ContextSwitcher;

namespace FeatureSwitcher.Configuration
{
    public interface IConfigureBehavior<TContext> where TContext : IContext
    {
        void Set(IControlFeatures value);
    }
}