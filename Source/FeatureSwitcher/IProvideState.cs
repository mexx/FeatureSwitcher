namespace FeatureSwitcher
{
    public interface IProvideState
    {
        bool IsEnabled<TFeature>()
            where TFeature : IFeature;
    }
}