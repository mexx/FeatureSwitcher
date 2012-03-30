using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class Simple : IFeature { }

    public class Complex : IFeature { }

    //public class Configuration : IFeature { }

    public class WithFeature<T> where T : IFeature
    {
        protected static bool FeatureEnabled { get; private set; }

        Cleanup clean = () => ControlFeatures.Behavior = null;

        Because of = () => FeatureEnabled = Feature<T>.IsEnabled;
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}