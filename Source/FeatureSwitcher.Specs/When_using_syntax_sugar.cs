using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Contexts;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_using_syntax_sugar : WithCleanUp
    {
        Because of = () => Features.Are.
                               NamedBy.TypeName().And.
                               NamedBy.TypeFullName().And.
                               ConfiguredBy.AppConfig().And.
                               ConfiguredBy.AppConfig().IgnoreConfigurationErrors().And.
                               ConfiguredBy.AppConfig().IgnoreConfigurationErrors().UsingConfigSectionGroup("test").And.
                               AlwaysDisabled().And.
                               AlwaysEnabled().And.
                               NamedBy.TypeName().
                               NamedBy.TypeFullName().
                               ConfiguredBy.AppConfig().
                               NamedBy.TypeName().
                               ConfiguredBy.AppConfig().IgnoreConfigurationErrors().
                               ConfiguredBy.AppConfig().IgnoreConfigurationErrors().UsingConfigSectionGroup("test").
                               NamedBy.TypeFullName().
                               AlwaysDisabled().
                               AlwaysEnabled().
                               HandledByDefault();

        It should_not_fail = () => true.ShouldBeTrue();
    }
}