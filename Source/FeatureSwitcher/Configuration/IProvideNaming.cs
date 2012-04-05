namespace FeatureSwitcher
{
    public interface IProvideNaming
    {
        string For<TFeature>() where TFeature : IFeature;
    }
}