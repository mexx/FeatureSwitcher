using FeatureSwitcher.Configuration;

namespace FeatureSwitcher.Specs
{
    public class TestConfigurationPartial<T> : IProvideBehavior, IProvideNaming
    {
        public readonly static TestConfigurationPartial<T> Instance = new TestConfigurationPartial<T>();

        bool? IProvideBehavior.IsEnabled(string feature)
        {
            if (feature == null)
                return true;

            if (feature == typeof(T).Name)
                return true;

            return null;
        }

        string IProvideNaming.For<TFeature>()
        {
            if (typeof(TFeature) == typeof(T))
                return typeof(T).Name;
            
            return null;
        }
    }
}