namespace FeatureSwitcher.Configuration
{
    public interface IProvideState
    {
        bool IsEnabled<TFeature>()
            where TFeature : IFeature;
    }
}