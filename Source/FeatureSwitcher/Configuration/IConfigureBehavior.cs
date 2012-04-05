using ContextSwitcher;

namespace FeatureSwitcher.Configuration
{
    public interface IConfigureBehavior<out TContext> where TContext : IContext
    {
        IFeatureConfiguration<TContext> Custom(ISupportContextFor<IControlFeatures, TContext> value);
        IFeatureConfiguration<TContext> Custom(IControlFeatures value);
    }
}