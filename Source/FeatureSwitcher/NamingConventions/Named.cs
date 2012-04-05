using ContextSwitcher;

namespace FeatureSwitcher.Configuration
{
    public static class Named
    {
        public static IFeatureConfiguration<TContext> TypeFullName<TContext>(this IConfigureNaming<TContext> This) where TContext : IContext
        {
            return This.Custom(Use.Type.FullName);
        }

        public static IFeatureConfiguration<TContext> TypeName<TContext>(this IConfigureNaming<TContext> This) where TContext : IContext
        {
            return This.Custom(Use.Type.Name);
        }
    }
}