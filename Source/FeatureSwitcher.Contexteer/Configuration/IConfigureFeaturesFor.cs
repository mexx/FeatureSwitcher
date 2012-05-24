using Contexteer;

namespace FeatureSwitcher.Configuration
{
    public interface IConfigureFeaturesFor<out TContext> : IConfigureFeatures
        where TContext : IContext
    {
        new IConfigureFeaturesFor<TContext> And { get; }

        new IConfigureNamingFor<TContext> NamedBy { get; }
        new IConfigureBehaviorFor<TContext> ConfiguredBy { get; }
    }
}