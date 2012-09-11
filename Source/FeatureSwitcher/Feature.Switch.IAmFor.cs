using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public static partial class Switch
        {
            public interface IAmFor<out T>
                where T : IFeature
            {
                IKnowStateOf<T> With(IProvideState provideState);
            }
        }
    }
}