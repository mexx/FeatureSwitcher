using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_chaining_application_configuration_and_partial_configurations : WithCleanUp
    {
        Establish ctx = () =>
                        Features.Are
                            .ConfiguredBy.Custom(
                                new AppConfig(true).Features,
                                EnableByName<Simple>.Instance.IsEnabled,
                                new AppConfig(true).Default).And
                            .NamedBy.Custom(
                                EnableByName<Simple>.Instance.For,
                                Features.OfAnyType.NamedByTypeFullName);

        Behaves_like<Disabled<Basic>> a_disabled_basic_feature;
        Behaves_like<DisabledInDefault<Basic>> a_disabled_basic_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Basic>> a_disabled_basic_feature_in_headquarters;

        Behaves_like<Enabled<Simple>> an_enabled_feature_simple;
        Behaves_like<EnabledInDefault<Simple>> an_enabled_feature_simple_in_default;
        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_feature_simple_in_headquarters;

        Behaves_like<Disabled<Complex>> a_disabled_complex_feature;
        Behaves_like<DisabledInDefault<Complex>> a_disabled_complex_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Complex>> a_disabled_complex_feature_in_headquarters;
    }
}