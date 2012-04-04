using ContextSwitcher;

namespace FeatureSwitcher.Configuration
{
    public static class Named
    {
        public static IFeatureConfiguration<TContext> TypeFullName<TContext>(this IConfigureNaming<TContext> This) where TContext : IContext
        {
            This.Set(Use.Type.FullName);
            return null;
        }

        public static IFeatureConfiguration<TContext> TypeName<TContext>(this IConfigureNaming<TContext> This) where TContext : IContext
        {
            This.Set(Use.Type.Name);
            return null;
        }
    }
}