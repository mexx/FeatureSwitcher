namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public static partial class Switch
        {
            /// <summary>
            /// Provides the state of feature of type <typeparamref name="T"/>.
            /// </summary>
            /// <typeparam name="T">The type of the feature.</typeparam>
            public class StateOf<T> : IKnowStateOf<T>
                where T : IFeature
            {
                private readonly Configuration _configuration;

                /// <summary>
                /// Constructs the state of feature using specified <paramref name="configuration"/>.
                /// </summary>
                /// <param name="configuration">The configuration to use to determine the state of the feature.</param>
                public StateOf(Configuration configuration)
                {
                    _configuration = configuration;
                }

                /// <summary>
                /// Gets whether the feature is enabled.
                /// </summary>
                public bool Enabled
                {
                    get { return _configuration.IsEnabled<T>(); }
                }

                /// <summary>
                /// Gets whether the feature is disabled.
                /// </summary>
                public bool Disabled
                {
                    get { return !Enabled; }
                }
            }
        }
    }
}