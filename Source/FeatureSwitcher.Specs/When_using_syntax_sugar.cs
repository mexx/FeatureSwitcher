using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_using_syntax_sugar : WithCleanUp
    {
        Because of = () => Features.Are.
                               NamedBy.TypeName().And.
                               NamedBy.TypeFullName().And.
                               ConfiguredBy.Custom(Features.OfType<Simple>.Enabled).And.
                               ConfiguredBy.Custom(Features.OfAnyType.Disabled).And.
                               AlwaysDisabled().And.
                               AlwaysEnabled().And.
                               NamedBy.TypeName().
                               NamedBy.TypeFullName().
                               ConfiguredBy.Custom().
                               NamedBy.TypeName().
                               ConfiguredBy.Custom(Features.OfAnyType.Enabled).
                               NamedBy.TypeFullName().
                               AlwaysDisabled().
                               AlwaysEnabled().
                               HandledByDefault();

        It should_not_fail = () => true.ShouldBeTrue();
    }
}