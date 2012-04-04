namespace FeatureSwitcher
{
    public static class Context
    {
        public static readonly IContext Default = null;

        public static FeatureInContext<T> Feature<T>(this IContext This) where T: IFeature
        {            
            return new FeatureInContext<T>(This);
        }

        public static FeatureInContext<T> Feature<T>(this IContext This, T feature) where T : IFeature
        {
            return new FeatureInContext<T>(This);
        }
    }
}