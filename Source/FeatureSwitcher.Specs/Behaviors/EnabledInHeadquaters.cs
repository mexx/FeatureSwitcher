using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs.Behaviors
{
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
}