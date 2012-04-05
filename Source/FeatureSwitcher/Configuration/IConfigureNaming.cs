namespace FeatureSwitcher.Configuration
{
    public interface IConfigureNamingIn<out TContext> where TContext : IContext
    {
        IConfigureFeaturesFor<TContext> Custom(IInContextOf<TContext, IProvideNaming> value);
        IConfigureFeaturesFor<TContext> Custom(IProvideNaming value);
    }
}