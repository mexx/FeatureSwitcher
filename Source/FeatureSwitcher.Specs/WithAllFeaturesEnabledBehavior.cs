using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
#pragma warning disable 169
    // ReSharper disable InconsistentNaming
    public class WithAllFeaturesEnabledBehavior : WithCleanUp
    {
        Establish ctx = () => Features.Are.AlwaysEnabled();
    }

    public class With_all_features_enabled_behavior_simple_feature : WithAllFeaturesEnabledBehavior
    {
        Behaves_like<Enabled<Simple>> an_enabled_feature;
    }

    public class With_all_features_enabled_behavior_complex_feature : WithAllFeaturesEnabledBehavior
    {
        Behaves_like<Enabled<Complex>> an_enabled_feature;
    }

    public class WithAllFeaturesDisabledBehavior : WithCleanUp
    {
        Establish ctx = () => Features.Are.AlwaysDisabled();
    }

    public class With_all_features_disabled_behavior_simple_feature : WithAllFeaturesDisabledBehavior
    {
        Behaves_like<Disabled<Simple>> a_disabled_feature;
    }

    public class With_all_features_disabled_behavior_complex_feature : WithAllFeaturesDisabledBehavior
    {
        Behaves_like<Disabled<Complex>> a_disabled_feature;
    }
    // ReSharper restore InconsistentNaming
#pragma warning restore 169
}