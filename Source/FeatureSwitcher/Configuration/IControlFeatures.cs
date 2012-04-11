namespace FeatureSwitcher.Configuration
{
    internal interface IControlFeatures
    {
        bool IsEnabled<TFeature>()
            where TFeature : IFeature;
    }
}