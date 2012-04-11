namespace FeatureSwitcher.Configuration.Internal
{
    internal interface IControlFeatures
    {
        bool IsEnabled<TFeature>()
            where TFeature : IFeature;
    }
}