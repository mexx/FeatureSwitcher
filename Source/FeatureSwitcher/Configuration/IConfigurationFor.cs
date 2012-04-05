namespace FeatureSwitcher.Configuration
{
    public interface IConfigurationFor<out TContext>
        where TContext : IContext
    {
        IConfigureFeaturesFor<TContext> FeaturesAre { get; }
    }
}