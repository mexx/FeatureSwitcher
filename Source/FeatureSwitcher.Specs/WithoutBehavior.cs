using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
#pragma warning disable 169
    // ReSharper disable InconsistentNaming
    public class WithoutBehavior : WithCleanUp
    {
        Establish ctx = () => Features.Are.AlwaysDisabled();
    }

    public class Without_behavior_simple_feature : WithoutBehavior
    {
        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;
    }

    public class Without_behavior_complex_feature : WithoutBehavior
    {
        Behaves_like<DisabledComplexFeatureBehavior> a_disabled_feature;
    }
    // ReSharper restore InconsistentNaming
#pragma warning restore 169
}