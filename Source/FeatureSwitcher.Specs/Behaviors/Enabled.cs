using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs.Behaviors
{
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
}