using Contexteer;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs.Behaviors
{
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
}