using ContextSwitcher;

namespace FeatureSwitcher.Configuration
{
    public interface IConfigureNaming<out TContext> where TContext : IContext
    {
        IFeatureConfiguration<TContext> Custom(ISupportContextFor<IProvideNaming, TContext> value);
        IFeatureConfiguration<TContext> Custom(IProvideNaming value);
    }
}