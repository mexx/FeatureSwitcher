namespace FeatureSwitcher.Configuration
{
    public static class Always
    {
        public static IConfigureFeaturesFor<TContext> AlwaysEnabled<TContext>(this IConfigureFeaturesFor<TContext> This)
            where TContext : IContext
        {
            return This.ConfiguredBy.Custom(AllFeatures.Enabled);
        }

        public static IConfigureFeaturesFor<TContext> AlwaysDisabled<TContext>(this IConfigureFeaturesFor<TContext> This)
            where TContext : IContext
        {
            return This.ConfiguredBy.Custom(AllFeatures.Disabled);
        }
    }
}