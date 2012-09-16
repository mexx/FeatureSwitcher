namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public static partial class Switch
        {
            public class StateOf<T> : IKnowStateOf<T>
                where T : IFeature
            {
                private readonly Configuration _configuration;

                public StateOf(Configuration configuration)
                {
                    _configuration = configuration;
                }

                public bool Enabled
                {
                    get { return _configuration.IsEnabled<T>(); }
                }

                public bool Disabled
                {
                    get { return !Enabled; }
                }
            }
        }
    }
}