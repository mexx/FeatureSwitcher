using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
#pragma warning disable 169
    // ReSharper disable InconsistentNaming
    public class WithAllFeaturesEnabled : WithCleanUp
    {
        Establish ctx = () => Features.Are.AlwaysEnabled();
    }

    public class With_all_features_enabled_behavior_simple_feature : WithAllFeaturesEnabled
    {
        Behaves_like<Enabled<Simple>> an_enabled_feature;
    }

    public class With_all_features_enabled_behavior_complex_feature : WithAllFeaturesEnabled
    {
        Behaves_like<Enabled<Complex>> an_enabled_feature;
    }
    // ReSharper restore InconsistentNaming
#pragma warning restore 169
}