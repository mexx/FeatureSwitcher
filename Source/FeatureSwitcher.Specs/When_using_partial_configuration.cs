using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_using_partial_configuration : WithCleanUp
    {
        Establish ctx = () => Features.Are.
                                  ConfiguredBy.Custom(EnableByName<Simple>.IsEnabled).And.
                                  NamedBy.Custom(Features.OfType<Simple>.NamedByTypeName);

        Behaves_like<Disabled<Basic>> a_disabled_basic_feature;

        Behaves_like<Enabled<Simple>> an_enabled_simple_feature;

        Behaves_like<Disabled<Complex>> a_disabled_complex_feature;
    }
}