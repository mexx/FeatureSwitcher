using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_features_are_disabled_by_default_section_and_simple_feature_explicitly_enabled_by_features_section : WithFeaturesDisabledByDefaultSection
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = typeof(Simple).FullName, Enabled = true });

        Behaves_like<Disabled<Basic>> a_disabled_basic_feature;
        Behaves_like<DisabledInDefault<Basic>> a_disabled_basic_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Basic>> a_disabled_basic_feature_in_headquarters;

        Behaves_like<Enabled<Simple>> an_enabled_simple_feature;
        Behaves_like<EnabledInDefault<Simple>> an_enabled_simple_feature_in_default;
        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_simple_feature_in_headquarters;

        Behaves_like<Disabled<Complex>> a_disabled_complex_feature;
        Behaves_like<DisabledInDefault<Complex>> a_disabled_complex_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Complex>> a_disabled_complex_feature_in_headquarters;
    }
}