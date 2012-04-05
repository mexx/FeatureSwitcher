namespace FeatureSwitcher.Configuration
{
    public static class Default
    {
        public static void HandledByDefault<TContext>(this IConfigureFeaturesFor<TContext> This)
            where TContext : IContext
        {
            This.ConfiguredBy.Custom((InContextOf<TContext, IControlFeatures>)null);
            This.NamedBy.Custom((InContextOf<TContext, IProvideNaming>)null);
        }
    }
}