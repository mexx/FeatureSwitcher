using ContextSwitcher;

namespace FeatureSwitcher.Configuration
{
    public interface IFeatureConfiguration<out TContext> where TContext : IContext
    {
        IFeatureConfiguration<TContext> And { get; }

        IConfigureNaming<TContext> NamedBy { get; }
        IConfigureBehavior<TContext> ConfiguredBy { get; }
    }
}