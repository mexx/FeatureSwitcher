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

        Behaves_like<Disabled<Basic>> a_disabled_basic_feature;
        Behaves_like<DisabledInDefault<Basic>> a_disabled_basic_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Basic>> a_disabled_basic_feature_in_headquarters;

        Behaves_like<Enabled<Simple>> an_enabled_simple_feature;
        Behaves_like<EnabledInDefault<Simple>> an_enabled_simple_feature_in_default;
        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_simple_feature_in_headquarters;

        Behaves_like<Enabled<Complex>> an_enabled_complex_feature;
        Behaves_like<EnabledInDefault<Complex>> an_enabled_complex_feature_in_default;
        Behaves_like<EnabledInHeadquaters<Complex>> an_enabled_complex_feature_in_headquarters;
    }
}