namespace FeatureSwitcher.Configuration
{
    public interface IConfigureFeaturesFor<out TContext> where TContext : IContext
    {
        IConfigureFeaturesFor<TContext> And { get; }

        IConfigureNamingIn<TContext> NamedBy { get; }
        IConfigureBehaviorIn<TContext> ConfiguredBy { get; }
    }
}