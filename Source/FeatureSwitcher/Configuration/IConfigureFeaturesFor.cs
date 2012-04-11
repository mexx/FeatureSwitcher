namespace FeatureSwitcher.Configuration
{
    public interface IConfigureFeaturesFor<out TContext>
        where TContext : IContext
    {
        IConfigureFeaturesFor<TContext> And { get; }

        IConfigureIn<TContext, IProvideNaming> NamedBy { get; }
        IConfigureIn<TContext, IProvideBehavior> ConfiguredBy { get; }
    }
}