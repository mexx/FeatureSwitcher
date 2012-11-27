namespace FeatureSwitcher
{
    public static partial class Feature
    {
        /// <summary>
        /// Can control whether the feature is enabled or disabled.
        /// </summary>
        /// <param name="featureName">The name of the feature.</param>
        /// <returns><c>true</c> if feature is enabled, <c>false</c> if not, <c>null</c> if the state of the feature can't be determined.</returns>
        public delegate bool? Behavior(Name featureName);
    }
}