namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public static partial class Switch
        {
            public class Of<T> : IAmFor<T>
                where T : IFeature
            {
                public IKnowStateOf<T> With(Configuration configuration)
                {
                    return new StateOf<T>(configuration);
                }
            }
        }
    }
}