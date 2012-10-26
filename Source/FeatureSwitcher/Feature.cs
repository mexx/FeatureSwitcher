namespace FeatureSwitcher
{
    /// <summary>
    /// Extension methods for a feature instance.
    /// </summary>
    public static partial class Feature
    {
        /// <summary>
        /// Provides an object which knows the state of the feature.
        /// </summary>
        /// <typeparam name="T">The type of the feature.</typeparam>
        /// <param name="This">Instance of the feature.</param>
        /// <returns>an object which knows the state of the feature.</returns>
        public static Switch.IKnowStateOf<T> Is<T>(this T This)
            where T : IFeature
        {
            return Switch.For<T>(This.GetType()).With(Configuration.Current);
        }
    }

    /// <summary>
    /// Extension methods for features of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the feature.</typeparam>
    public static class Feature<T>
        where T : IFeature
    {
        /// <summary>
        /// Provides an object which knows the state of the feature.
        /// </summary>
        /// <returns>an object which knows the state of the feature.</returns>
        public static Feature.Switch.IKnowStateOf<T> Is()
        {
            return Feature.Switch.For<T>().With(Feature.Configuration.Current);
        }
    }
}