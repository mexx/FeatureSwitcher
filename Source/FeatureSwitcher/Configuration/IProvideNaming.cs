namespace FeatureSwitcher.Configuration
{
    public interface IProvideNaming
    {
        string For<TFeature>()
            where TFeature : IFeature;
    }
}