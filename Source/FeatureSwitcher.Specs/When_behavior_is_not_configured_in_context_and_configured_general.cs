using Contexteer.Configuration;
using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_behavior_is_not_configured_in_context_and_configured_general : WithCleanUp
    {
        Establish ctx = () =>
                            {
                                Features.Are.
                                    ConfiguredBy.Custom(
                                        EnableByName<Basic>.Instance.IsEnabled,
                                        EnableByName<Simple>.Instance.IsEnabled, 
                                        EnableByName<Complex>.Instance.IsEnabled).And.
                                    NamedBy.TypeName();

                                In<BusinessBranch>.Contexts.FeaturesAre().
                                    NamedBy.TypeFullName();
                            };

        Behaves_like<Enabled<Basic>> a_disabled_basic_feature;
        Behaves_like<EnabledInDefault<Basic>> a_disabled_basic_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Basic>> a_disabled_basic_feature_in_headquarters;

        Behaves_like<Enabled<Simple>> a_disabled_simple_feature;
        Behaves_like<EnabledInDefault<Simple>> a_disabled_simple_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Simple>> an_enabled_feature_in_headquarters;

        Behaves_like<Enabled<Complex>> a_disabled_complex_feature;
        Behaves_like<EnabledInDefault<Complex>> a_disabled_complex_feature_in_default;
        Behaves_like<DisabledInHeadquaters<Complex>> a_disabled_complex_feature_in_headquarters;
    }
}