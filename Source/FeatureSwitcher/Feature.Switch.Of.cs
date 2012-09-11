using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public static partial class Switch
        {
            public class Of<T> : IAmFor<T>
                where T : IFeature
            {
                public IKnowStateOf<T> With(IProvideState provideState)
                {
                    return new StateOf<T>(provideState);
                }
            }
        }
    }
}