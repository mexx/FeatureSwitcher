namespace FeatureSwitcher.Configuration
{
    public interface IConfigureBehaviorIn<out TContext> where TContext : IContext
    {
        IConfigureFeaturesFor<TContext> Custom(IInContextOf<TContext, IControlFeatures> value);
        IConfigureFeaturesFor<TContext> Custom(IControlFeatures value);
    }
}