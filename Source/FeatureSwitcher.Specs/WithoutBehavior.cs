using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class WithoutBehavior<T> : WithFeature<T> where T : IFeature
    {
        Establish ctx = () => ControlFeatures.Behavior = null;
    }

    public class Without_behavior_simple_feature : WithoutBehavior<Simple>
    {
        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }

    public class Without_behavior_complex_feature : WithoutBehavior<Complex>
    {
        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Complex().IsEnabled());
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}