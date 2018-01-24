using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_chaining_multiple_partial_configurations : WithCleanUp
    {
        Establish ctx = () => Features.Are.
                                  ConfiguredBy.Custom(EnableByName<Simple>.IsEnabled, EnableByName<Complex>.IsEnabled).And.
                                  NamedBy.Custom(Features.OfType<Simple>.NamedByTypeName, Features.OfType<Complex>.NamedByTypeName);

        class when_using_basic
        {
            Behaves_like<Disabled<Basic>> a_disabled_basic_feature;
        }

        class when_using_simple
        {
            Behaves_like<Enabled<Simple>> an_enabled_simple_feature;
        }

        class when_using_complex
        {
            Behaves_like<Enabled<Complex>> an_enabled_complex_feature;
        }
    }
}