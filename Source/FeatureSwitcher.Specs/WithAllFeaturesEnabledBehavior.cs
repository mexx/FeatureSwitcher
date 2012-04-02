using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class WithAllFeaturesEnabledBehavior<T> : WithFeature<T> where T : IFeature
    {
        Establish ctx = () => ControlFeatures.Behavior = Use.AllFeatures.Enabled;
    }

    public class With_all_features_enabled_behavior_simple_feature : WithAllFeaturesEnabledBehavior<Simple>
    {
        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }

    public class With_all_features_enabled_behavior_complex_feature : WithAllFeaturesEnabledBehavior<Complex>
    {
        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Complex().IsEnabled());
    }

    public class WithAllFeaturesDisabledBehavior<T> : WithFeature<T> where T : IFeature
    {
        Establish ctx = () => ControlFeatures.Behavior = Use.AllFeatures.Disabled;
    }

    public class With_all_features_disabled_behavior_simple_feature : WithAllFeaturesDisabledBehavior<Simple>
    {
        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }

    public class With_all_features_disabled_behavior_complex_feature : WithAllFeaturesDisabledBehavior<Complex>
    {
        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Complex().IsEnabled());
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}