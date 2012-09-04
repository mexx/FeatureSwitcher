using FeatureSwitcher.Configuration;

namespace FeatureSwitcher.Specs.Domain
{
    public class EnableByName<T> : IProvideBehavior, IProvideNaming
    {
        public readonly static EnableByName<T> Instance = new EnableByName<T>();

        public bool? IsEnabled(string feature)
        {
            if (feature == null)
                return true;

            if (feature == typeof(T).Name)
                return true;

            return null;
        }

        public string For<TFeature>() where TFeature : IFeature
        {
            if (typeof(TFeature) == typeof(T))
                return typeof(T).Name;

            return null;
        }
    }
}