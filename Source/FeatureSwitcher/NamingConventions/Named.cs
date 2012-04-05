namespace FeatureSwitcher.Configuration
{
    public static class Named
    {
        public static IConfigureFeaturesFor<TContext> TypeFullName<TContext>(this IConfigureNamingIn<TContext> This) where TContext : IContext
        {
            return This.Custom(Use.Type.FullName);
        }

        public static IConfigureFeaturesFor<TContext> TypeName<TContext>(this IConfigureNamingIn<TContext> This) where TContext : IContext
        {
            return This.Custom(Use.Type.Name);
        }
    }
}