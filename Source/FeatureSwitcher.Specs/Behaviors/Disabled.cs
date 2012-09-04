using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs.Behaviors
{
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
}