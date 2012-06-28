using Contexteer;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    [Behaviors]
    public class Enabled<TComponent> where TComponent : IComponent, new()
    {
        It should_be_enabled_as_generic = () => Feature<TComponent>.Is().Enabled.ShouldBeTrue();

        It should_be_enabled_as_base_instance = () => ((IComponent)new TComponent()).Is().Enabled.ShouldBeTrue();

        It should_be_enabled_as_instance = () => new TComponent().Is().Enabled.ShouldBeTrue();

        It should_be_not_disabled_as_generic = () => Feature<TComponent>.Is().Disabled.ShouldBeFalse();

        It should_be_not_disabled_as_base_instance = () => ((IComponent)new TComponent()).Is().Disabled.ShouldBeFalse();

        It should_be_not_disabled_as_instance = () => new TComponent().Is().Disabled.ShouldBeFalse();
    }

    [Behaviors]
    public class EnabledInDefault<TComponent> where TComponent : IComponent, new()
    {
        It should_be_enabled_as_generic = () => Feature<TComponent>.Is().EnabledInContextOf(Default.Context).ShouldBeTrue();

        It should_be_enabled_as_base_instance = () => ((IComponent)new TComponent()).Is().EnabledInContextOf(Default.Context).ShouldBeTrue();

        It should_be_enabled_as_instance = () => new TComponent().Is().EnabledInContextOf(Default.Context).ShouldBeTrue();

        It should_be_not_disabled_as_generic = () => Feature<TComponent>.Is().DisabledInContextOf(Default.Context).ShouldBeFalse();

        It should_be_not_disabled_as_base_instance = () => ((IComponent)new TComponent()).Is().DisabledInContextOf(Default.Context).ShouldBeFalse();

        It should_be_not_disabled_as_instance = () => new TComponent().Is().DisabledInContextOf(Default.Context).ShouldBeFalse();
    }

    [Behaviors]
    public class EnabledInHeadquaters<TComponent> where TComponent : IComponent, new()
    {
        It should_be_enabled_as_generic = () => Feature<TComponent>.Is().EnabledInContextOf(BusinessBranch.Headquarters).ShouldBeTrue();

        It should_be_enabled_as_base_instance = () => ((IComponent)new TComponent()).Is().EnabledInContextOf(BusinessBranch.Headquarters).ShouldBeTrue();

        It should_be_enabled_as_instance = () => new TComponent().Is().EnabledInContextOf(BusinessBranch.Headquarters).ShouldBeTrue();

        It should_be_not_disabled_as_generic = () => Feature<TComponent>.Is().DisabledInContextOf(BusinessBranch.Headquarters).ShouldBeFalse();

        It should_be_not_disabled_as_base_instance = () => ((IComponent)new TComponent()).Is().DisabledInContextOf(BusinessBranch.Headquarters).ShouldBeFalse();

        It should_be_not_disabled_as_instance = () => new TComponent().Is().DisabledInContextOf(BusinessBranch.Headquarters).ShouldBeFalse();
    }

    [Behaviors]
    public class Disabled<TComponent> where TComponent : IComponent, new()
    {
        It should_be_disabled_as_generic = () => Feature<TComponent>.Is().Disabled.ShouldBeTrue();

        It should_be_disabled_as_base_instance = () => ((IComponent)new TComponent()).Is().Disabled.ShouldBeTrue();

        It should_be_disabled_as_instance = () => new TComponent().Is().Disabled.ShouldBeTrue();

        It should_be_not_enabled_as_generic = () => Feature<TComponent>.Is().Enabled.ShouldBeFalse();

        It should_be_not_enabled_as_base_instance = () => ((IComponent)new TComponent()).Is().Enabled.ShouldBeFalse();

        It should_be_not_enabled_as_instance = () => new TComponent().Is().Enabled.ShouldBeFalse();
    }

    [Behaviors]
    public class DisabledInDefault<TComponent> where TComponent : IComponent, new()
    {
        It should_be_disabled_as_generic = () => Feature<TComponent>.Is().DisabledInContextOf(Default.Context).ShouldBeTrue();

        It should_be_disabled_as_base_instance = () => ((IComponent)new TComponent()).Is().DisabledInContextOf(Default.Context).ShouldBeTrue();

        It should_be_disabled_as_instance = () => new TComponent().Is().DisabledInContextOf(Default.Context).ShouldBeTrue();

        It should_be_not_enabled_as_generic = () => Feature<TComponent>.Is().EnabledInContextOf(Default.Context).ShouldBeFalse();

        It should_be_not_enabled_as_base_instance = () => ((IComponent)new TComponent()).Is().EnabledInContextOf(Default.Context).ShouldBeFalse();

        It should_be_not_enabled_as_instance = () => new TComponent().Is().EnabledInContextOf(Default.Context).ShouldBeFalse();
    }

    [Behaviors]
    public class DisabledInHeadquaters<TComponent> where TComponent : IComponent, new()
    {
        It should_be_disabled_as_generic = () => Feature<TComponent>.Is().DisabledInContextOf(BusinessBranch.Headquarters).ShouldBeTrue();

        It should_be_disabled_as_base_instance = () => ((IComponent)new TComponent()).Is().DisabledInContextOf(BusinessBranch.Headquarters).ShouldBeTrue();

        It should_be_disabled_as_instance = () => new TComponent().Is().DisabledInContextOf(BusinessBranch.Headquarters).ShouldBeTrue();

        It should_be_not_enabled_as_generic = () => Feature<TComponent>.Is().EnabledInContextOf(BusinessBranch.Headquarters).ShouldBeFalse();

        It should_be_not_enabled_as_base_instance = () => ((IComponent)new TComponent()).Is().EnabledInContextOf(BusinessBranch.Headquarters).ShouldBeFalse();

        It should_be_not_enabled_as_instance = () => new TComponent().Is().EnabledInContextOf(BusinessBranch.Headquarters).ShouldBeFalse();
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}