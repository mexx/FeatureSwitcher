using Contexteer;
using Contexteer.Configuration;
using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_using_partial_configuration_and_contexts : WithCleanUp
    {
        Establish ctx = () =>
                            {
                                Features.Are.
                                    ConfiguredBy.Custom(EnableByName<Simple>.Instance).And.
                                    NamedBy.Custom(EnableByName<Simple>.Instance.For);

                                In<Default>.Contexts.FeaturesAre().
                                    ConfiguredBy.Custom(EnableByName<Basic>.Instance).And.
                                    NamedBy.Custom(EnableByName<Basic>.Instance.For);

                                In<BusinessBranch>.Contexts.FeaturesAre().
                                    ConfiguredBy.Custom(EnableByName<Complex>.Instance).And.
                                    NamedBy.Custom(EnableByName<Complex>.Instance.For);
                            };

        Behaves_like<Disabled<Basic>> a_disabled_feature_basic;
        Behaves_like<EnabledInDefault<Basic>> an_enabled_feature_basic_in_default;
        Behaves_like<EnabledInHeadquaters<Basic>> an_enabled_feature_basic_in_headquarters;

        Behaves_like<Enabled<Simple>> an_enabled_feature_simple;
        Behaves_like<EnabledInDefault<Simple>> an_enabled_feature_simple_in_default;
        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_feature_simple_in_headquarters;

        Behaves_like<Disabled<Complex>> a_disabled_feature_complex;
        Behaves_like<DisabledInDefault<Complex>> an_enabled_feature_complex_in_default;
        Behaves_like<EnabledInHeadquaters<Complex>> an_enabled_feature_complex_in_headquarters;
    }
}