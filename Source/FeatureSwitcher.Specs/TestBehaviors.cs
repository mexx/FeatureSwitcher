using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    // TODO: rewrite using generics
    [Behaviors]
    public class EnabledSimpleFeatureBehavior
    {
        It should_be_enabled_as_generic = () => Feature<Simple>.IsEnabled.ShouldBeTrue();

        It should_be_enabled_as_instance = () => new Simple().IsEnabled().ShouldBeTrue();

        It should_be_not_disabled_as_generic = () => Feature<Simple>.IsDisabled.ShouldBeFalse();

        It should_be_not_disabled_as_instance = () => new Simple().IsDisabled().ShouldBeFalse();
    }
    
    [Behaviors]
    public class EnabledSimpleFeatureInHeadquatersBehavior
    {
        It should_be_enabled_as_generic = () => BusinessBranch.Headquarters.Feature<Simple>().IsEnabled.ShouldBeTrue();

        It should_be_enabled_as_instance = () => BusinessBranch.Headquarters.Feature(new Simple()).IsEnabled.ShouldBeTrue();

        It should_be_not_disabled_as_generic = () => BusinessBranch.Headquarters.Feature<Simple>().IsDisabled.ShouldBeFalse();

        It should_be_not_disabled_as_instance = () => BusinessBranch.Headquarters.Feature(new Simple()).IsDisabled.ShouldBeFalse();
    }
    
    [Behaviors]
    public class DisabledSimpleFeatureBehavior
    {
        It should_be_disabled_as_generic = () => Feature<Simple>.IsDisabled.ShouldBeTrue();

        It should_be_disabled_as_instance = () => new Simple().IsDisabled().ShouldBeTrue();

        It should_be_not_enabled_as_generic = () => Feature<Simple>.IsEnabled.ShouldBeFalse();

        It should_be_not_enabled_as_instance = () => new Simple().IsEnabled().ShouldBeFalse();
    }

    [Behaviors]
    public class EnabledComplexFeatureBehavior
    {
        It should_be_enabled_as_generic = () => Feature<Complex>.IsEnabled.ShouldBeTrue();

        It should_be_enabled_as_instance = () => new Complex().IsEnabled().ShouldBeTrue();

        It should_be_not_disabled_as_generic = () => Feature<Complex>.IsDisabled.ShouldBeFalse();

        It should_be_not_disabled_as_instance = () => new Complex().IsDisabled().ShouldBeFalse();
    }

    [Behaviors]
    public class DisabledComplexFeatureBehavior
    {
        It should_be_disabled_as_generic = () => Feature<Complex>.IsDisabled.ShouldBeTrue();

        It should_be_disabled_as_instance = () => new Complex().IsDisabled().ShouldBeTrue();

        It should_be_not_enabled_as_generic = () => Feature<Complex>.IsEnabled.ShouldBeFalse();

        It should_be_not_enabled_as_instance = () => new Complex().IsEnabled().ShouldBeFalse();
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}