namespace FeatureSwitcher.Configuration
{
    public interface IConfigureIn<out TContext, in TControl>
        where TContext : IContext
    {
        IConfigureFeaturesFor<TContext> Custom(InContextOf<TContext, TControl> value);
        IConfigureFeaturesFor<TContext> Custom(TControl value);
    }
}