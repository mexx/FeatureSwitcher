using FeatureSwitcher.Behaviors;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class WithAllFeaturesEnabledBehavior<T> : WithFeature<T> where T : IFeature
    {
        Establish ctx = () => ControlFeatures.Behavior = new AllFeaturesEnabled(true);
    }

    public class With_all_features_enabled_behavior_simple_feature : WithAllFeaturesEnabledBehavior<Simple>
    {
        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();
    }

    public class With_all_features_enabled_behavior_complex_feature : WithAllFeaturesEnabledBehavior<Complex>
    {
        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();
    }

    public class WithAllFeaturesDisabledBehavior<T> : WithFeature<T> where T : IFeature
    {
        Establish ctx = () => ControlFeatures.Behavior = new AllFeaturesEnabled(false);
    }

    public class With_all_features_disabled_behavior_simple_feature : WithAllFeaturesDisabledBehavior<Simple>
    {
        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();
    }

    public class With_all_features_disabled_behavior_complex_feature : WithAllFeaturesDisabledBehavior<Complex>
    {
        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}