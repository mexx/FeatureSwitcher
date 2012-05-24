using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    // TODO: rewrite using generics
    [Behaviors]
    public class EnabledSimpleFeatureBehavior
    {
        It should_be_enabled_as_generic = () => Feature<Simple>.Is().Enabled.ShouldBeTrue();

        It should_be_enabled_as_instance = () => new Simple().Is().Enabled.ShouldBeTrue();

        It should_be_not_disabled_as_generic = () => Feature<Simple>.Is().Disabled.ShouldBeFalse();

        It should_be_not_disabled_as_instance = () => new Simple().Is().Disabled.ShouldBeFalse();
    }
    
    [Behaviors]
    public class EnabledSimpleFeatureInHeadquatersBehavior
    {
        It should_be_enabled_as_generic = () => Feature<Simple>.Is().EnabledInContextOf(BusinessBranch.Headquarters).ShouldBeTrue();

        It should_be_enabled_as_instance = () => new Simple().Is().EnabledInContextOf(BusinessBranch.Headquarters).ShouldBeTrue();

        It should_be_not_disabled_as_generic = () => Feature<Simple>.Is().DisabledInContextOf(BusinessBranch.Headquarters).ShouldBeFalse();

        It should_be_not_disabled_as_instance = () => new Simple().Is().DisabledInContextOf(BusinessBranch.Headquarters).ShouldBeFalse();
    }
    
    [Behaviors]
    public class DisabledSimpleFeatureBehavior
    {
        It should_be_disabled_as_generic = () => Feature<Simple>.Is().Disabled.ShouldBeTrue();

        It should_be_disabled_as_instance = () => new Simple().Is().Disabled.ShouldBeTrue();

        It should_be_not_enabled_as_generic = () => Feature<Simple>.Is().Enabled.ShouldBeFalse();

        It should_be_not_enabled_as_instance = () => new Simple().Is().Enabled.ShouldBeFalse();
    }

    [Behaviors]
    public class EnabledComplexFeatureBehavior
    {
        It should_be_enabled_as_generic = () => Feature<Complex>.Is().Enabled.ShouldBeTrue();

        It should_be_enabled_as_instance = () => new Complex().Is().Enabled.ShouldBeTrue();

        It should_be_not_disabled_as_generic = () => Feature<Complex>.Is().Disabled.ShouldBeFalse();

        It should_be_not_disabled_as_instance = () => new Complex().Is().Disabled.ShouldBeFalse();
    }

    [Behaviors]
    public class DisabledComplexFeatureBehavior
    {
        It should_be_disabled_as_generic = () => Feature<Complex>.Is().Disabled.ShouldBeTrue();

        It should_be_disabled_as_instance = () => new Complex().Is().Disabled.ShouldBeTrue();

        It should_be_not_enabled_as_generic = () => Feature<Complex>.Is().Enabled.ShouldBeFalse();

        It should_be_not_enabled_as_instance = () => new Complex().Is().Enabled.ShouldBeFalse();
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}