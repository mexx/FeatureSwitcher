namespace FeatureSwitcher.Configuration.Internal
{
    internal interface IControlFeatureInContextsOfType<in T>
        where T : IContext
    {
        bool IsEnabled<TFeature>(T context)
            where TFeature : IFeature;
    }
}