using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_using_without_configuration
    {
        Behaves_like<Disabled<Basic>> a_disabled_basic_feature;

        Behaves_like<Disabled<Simple>> a_disabled_simple_feature;

        Behaves_like<Disabled<Complex>> a_disabled_complex_feature;
    }
}