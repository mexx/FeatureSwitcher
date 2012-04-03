using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class WithAllFeaturesEnabledBehavior : WithCleanUp
    {
        Establish ctx = () => ControlFeatures.Behavior = Use.AllFeatures.Enabled;
    }

    public class With_all_features_enabled_behavior_simple_feature : WithAllFeaturesEnabledBehavior
    {
        Behaves_like<EnabledSimpleFeatureBehavior> an_enabled_feature;
    }

    public class With_all_features_enabled_behavior_complex_feature : WithAllFeaturesEnabledBehavior
    {
        Behaves_like<EnabledComplexFeatureBehavior> an_enabled_feature;
    }

    public class WithAllFeaturesDisabledBehavior : WithCleanUp
    {
        Establish ctx = () => ControlFeatures.Behavior = Use.AllFeatures.Disabled;
    }

    public class With_all_features_disabled_behavior_simple_feature : WithAllFeaturesDisabledBehavior
    {
        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;
    }

    public class With_all_features_disabled_behavior_complex_feature : WithAllFeaturesDisabledBehavior
    {
        Behaves_like<DisabledComplexFeatureBehavior> a_disabled_feature;
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}