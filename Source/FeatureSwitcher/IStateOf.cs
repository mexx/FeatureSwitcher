namespace FeatureSwitcher
{
    /// <summary>
    /// Provides the state of <typeparamref name="TFeature"/>
    /// </summary>
    /// <typeparam name="TFeature">The type of the feature.</typeparam>
    public interface IStateOf<out TFeature>
        where TFeature : IFeature
    {
        /// <summary>
        /// Gets whether the feature is enabled
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Gets whether the feature is disabled
        /// </summary>
        bool Disabled { get; }
    }
}