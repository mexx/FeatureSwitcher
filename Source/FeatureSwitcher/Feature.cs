namespace FeatureSwitcher
{
    /// <summary>
    /// Extension methods for a feature.
    /// </summary>
    public static partial class Feature
    {
        public static Switch.IKnowStateOf<T> Is<T>(this T This)
            where T : IFeature
        {
            return Switch.For<T>(This.GetType()).With(Configuration.Current);
        }
    }

    /// <summary>
    /// Extension methods for <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the feature.</typeparam>
    public static class Feature<T>
        where T : IFeature
    {
        public static Feature.Switch.IKnowStateOf<T> Is()
        {
            return Feature.Switch.For<T>().With(Feature.Configuration.Current);
        }
    }
}