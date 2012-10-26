namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public static partial class Switch
        {
            /// <summary>
            /// Represents the switch for feature of type <typeparamref name="T"/>.
            /// </summary>
            /// <typeparam name="T">The type of the feature.</typeparam>
            public class Of<T> : IAmFor<T>
                where T : IFeature
            {
                /// <summary>
                /// Provides an object which knows the state of the feature using specified <paramref name="configuration"/>.
                /// </summary>
                /// <param name="configuration">The configuration to use to determine the state of the feature.</param>
                /// <returns>an object which knows the state of the feature using specified <paramref name="configuration"/>.</returns>
                public IKnowStateOf<T> With(Configuration configuration)
                {
                    return new StateOf<T>(configuration);
                }
            }
        }
    }
}