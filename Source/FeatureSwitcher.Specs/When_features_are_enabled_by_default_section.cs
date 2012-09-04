using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_features_are_enabled_by_default_section : WithFeaturesEnabledByDefaultSection
    {
        Behaves_like<Enabled<Basic>> an_enabled_basic_feature;
        Behaves_like<EnabledInDefault<Basic>> an_enabled_basic_feature_in_default;
        Behaves_like<EnabledInHeadquaters<Basic>> an_enabled_basic_feature_in_headquarters;

        Behaves_like<Enabled<Simple>> an_enabled_simple_feature;
        Behaves_like<EnabledInDefault<Simple>> an_enabled_simple_feature_in_default;
        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_simple_feature_in_headquarters;

        Behaves_like<Enabled<Complex>> an_enabled_complex_feature;
        Behaves_like<EnabledInDefault<Complex>> an_enabled_complex_feature_in_default;
        Behaves_like<EnabledInHeadquaters<Complex>> an_enabled_complex_feature_in_headquarters;
    }
}