namespace FeatureSwitcher.Configuration
{
    public interface IConfigureAppConfigFor<out TContext> : IConfigureFeaturesFor<TContext>
        where TContext : IContext
    {
        IConfigureAppConfigFor<TContext> IgnoreConfigurationErrors();
        IConfigureAppConfigFor<TContext> UsingConfigSectionGroup(string name);
    }
}