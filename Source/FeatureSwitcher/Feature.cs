using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    /// <summary>
    /// Extension methods for <typeparamref name="TFeature"/>.
    /// </summary>
    /// <typeparam name="TFeature">The type of the feature.</typeparam>
    public static class Feature<TFeature>
        where TFeature : IFeature
    {
        public static IStateOf<TFeature> Is()
        {
            return new StateOf<TFeature>(ProvideState.Control);
        }
    }

    /// <summary>
    /// Extension methods for a feature.
    /// </summary>
    public static class Feature
    {
        public static IStateOf<TFeature> Is<TFeature>(this TFeature This)
            where TFeature : IFeature
        {
            return Feature<TFeature>.Is();
        }
    }
}