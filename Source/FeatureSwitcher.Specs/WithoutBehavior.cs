using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class WithoutBehavior : WithCleanUp
    {
        Establish ctx = () => ByDefault.FeaturesAre.AlwaysDisabled();
    }

    public class Without_behavior_simple_feature : WithoutBehavior
    {
        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;
    }

    public class Without_behavior_complex_feature : WithoutBehavior
    {
        Behaves_like<DisabledComplexFeatureBehavior> a_disabled_feature;
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}