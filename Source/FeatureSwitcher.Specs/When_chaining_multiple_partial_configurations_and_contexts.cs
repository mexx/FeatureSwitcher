using Contexteer;
using Contexteer.Configuration;
using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_chaining_multiple_partial_configurations_and_contexts : WithCleanUp
    {
        Establish ctx = () =>
                            {
                                Features.Are
                                    .ConfiguredBy.Custom(EnableByName<Simple>.Instance, EnableByName<Complex>.Instance).And
                                    .NamedBy.Custom(EnableByName<Simple>.Instance, EnableByName<Complex>.Instance);

                                In<Default>.Contexts.FeaturesAre()
                                    .AlwaysDisabled().And
                                    .NamedBy.TypeFullName();

                                In<BusinessBranch>.Contexts.FeaturesAre()
                                    .ConfiguredBy.Custom(EnableByName<Basic>.Instance).And
                                    .NamedBy.Custom(EnableByName<Basic>.Instance);
                            };

        Behaves_like<Enabled<Simple>> an_enabled_feature_simple;
        Behaves_like<DisabledInDefault<Simple>> a_disabled_feature_simple_in_default;
        Behaves_like<DisabledInHeadquaters<Simple>> a_disabled_feature_simple_in_headquarters;

        Behaves_like<Disabled<Basic>> a_disabled_feature_basic;
        Behaves_like<DisabledInDefault<Basic>> a_disabled_feature_basic_in_default;
        Behaves_like<EnabledInHeadquaters<Basic>> an_enabled_feature_basic_in_headquarters;

        Behaves_like<Enabled<Complex>> an_enabled_feature_complex;
        Behaves_like<DisabledInDefault<Complex>> a_disabled_feature_complex_in_default;
        Behaves_like<DisabledInHeadquaters<Complex>> a_disabled_feature_complex_in_headquarters;
    }
}