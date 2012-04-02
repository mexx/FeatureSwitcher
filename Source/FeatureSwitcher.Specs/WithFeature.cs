using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class Simple : IFeature
    {
        public static string FullName { get { return typeof(Simple).FullName; } }
        public static string Name { get { return typeof (Simple).Name; } }
    }

    public class Complex : IFeature
    {
        public static string FullName { get { return typeof(Complex).FullName; } }
    }

    public class WithFeature<T> where T : IFeature
    {
        protected static bool FeatureEnabled { get; private set; }

        Cleanup clean = () =>
                                {
                                    ControlFeatures.Behavior = null;
                                    ControlFeatures.Name = null;
                                };

        Because of = () => FeatureEnabled = Feature<T>.IsEnabled;
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}