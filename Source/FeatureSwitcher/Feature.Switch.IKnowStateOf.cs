namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public static partial class Switch
        {
            /// <summary>
            /// Provides the state of <typeparamref name="T"/>
            /// </summary>
            /// <typeparam name="T">The type of the feature.</typeparam>
            public interface IKnowStateOf<out T>
                where T : IFeature
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
    }
}