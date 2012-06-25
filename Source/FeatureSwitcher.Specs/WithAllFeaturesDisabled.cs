using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
#pragma warning disable 169
    // ReSharper disable InconsistentNaming
    public class WithAllFeaturesDisabled : WithCleanUp
    {
        Establish ctx = () => Features.Are.AlwaysDisabled();
    }

    public class With_all_features_disabled_behavior_simple_feature : WithAllFeaturesDisabled
    {
        Behaves_like<Disabled<Simple>> a_disabled_feature;
    }

    public class With_all_features_disabled_behavior_complex_feature : WithAllFeaturesDisabled
    {
        Behaves_like<Disabled<Complex>> a_disabled_feature;
    }
    // ReSharper restore InconsistentNaming
#pragma warning restore 169
}