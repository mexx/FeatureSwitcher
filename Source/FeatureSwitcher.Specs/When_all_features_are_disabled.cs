using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_all_features_are_disabled : WithCleanUp
    {
        Because of = () => Features.Are.AlwaysDisabled();

        Behaves_like<Disabled<Basic>> a_disabled_basic_feature;
        Behaves_like<DisabledInDefault<Basic>> a_disabled_basic_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Basic>> a_disabled_basic_feature_in_headquarters;

        Behaves_like<Disabled<Simple>> a_disabled_simple_feature;
        Behaves_like<DisabledInDefault<Simple>> a_disabled_simple_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Simple>> a_disabled_simple_feature_in_headquarters;

        Behaves_like<Disabled<Complex>> a_disabled_complex_feature;
        Behaves_like<DisabledInDefault<Complex>> a_disabled_complex_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Complex>> a_disabled_complex_feature_in_headquarters;
    }
}