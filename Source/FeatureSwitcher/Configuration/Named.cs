namespace FeatureSwitcher.Configuration
{
    public static class Named
    {
        public static IConfigureFeaturesFor<TContext> TypeFullName<TContext>(this IConfigureIn<TContext, IProvideNaming> This)
            where TContext : IContext
        {
            return This.Custom(ProvideNaming.ByTypeFullName);
        }

        public static IConfigureFeaturesFor<TContext> TypeName<TContext>(this IConfigureIn<TContext, IProvideNaming> This)
            where TContext : IContext
        {
            return This.Custom(ProvideNaming.ByTypeName);
        }
    }
}