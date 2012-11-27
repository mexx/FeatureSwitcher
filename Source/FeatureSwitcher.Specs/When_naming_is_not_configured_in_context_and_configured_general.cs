using Contexteer.Configuration;
using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_naming_is_not_configured_in_context_and_configured_general : WithCleanUp
    {
        Establish ctx = () =>
        {
            Features.Are.NamedBy.TypeName();

            In<BusinessBranch>.Contexts.FeaturesAre().
                ConfiguredBy.Custom(Features.OfType<Simple>.Enabled);
        };


        Behaves_like<Disabled<Basic>> a_disabled_basic_feature;
        Behaves_like<DisabledInDefault<Basic>> a_disabled_basic_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Basic>> a_disabled_basic_feature_in_headquarters;

        Behaves_like<Disabled<Simple>> a_disabled_simple_feature;
        Behaves_like<DisabledInDefault<Simple>> a_disabled_simple_feature_in_default;
        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_feature_in_headquarters;

        Behaves_like<Disabled<Complex>> a_disabled_complex_feature;
        Behaves_like<DisabledInDefault<Complex>> a_disabled_complex_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Complex>> a_disabled_complex_feature_in_headquarters;
    }
}