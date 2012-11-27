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
                                    .ConfiguredBy.Custom(EnableByName<Simple>.IsEnabled, EnableByName<Complex>.IsEnabled).And
                                    .NamedBy.Custom(Features.OfType<Simple>.NamedByTypeName, Features.OfType<Complex>.NamedByTypeName);

                                In<Default>.Contexts.FeaturesAre()
                                    .ConfiguredBy.Custom(Features.OfType<Simple>.Disabled, Features.OfType<Basic>.Disabled, Features.OfAnyType.Enabled).And
                                    .NamedBy.TypeFullName();

                                In<BusinessBranch>.Contexts.FeaturesAre()
                                    .ConfiguredBy.Custom(EnableByName<Basic>.IsEnabled).And
                                    .NamedBy.Custom(Features.OfType<Basic>.NamedByTypeName);
                            };

        Behaves_like<Enabled<Simple>> an_enabled_feature_simple;
        Behaves_like<DisabledInDefault<Simple>> a_disabled_feature_simple_in_default;
        Behaves_like<DisabledInHeadquaters<Simple>> a_disabled_feature_simple_in_headquarters;

        Behaves_like<Disabled<Basic>> a_disabled_feature_basic;
        Behaves_like<DisabledInDefault<Basic>> a_disabled_feature_basic_in_default;
        Behaves_like<EnabledInHeadquaters<Basic>> an_enabled_feature_basic_in_headquarters;

        Behaves_like<Enabled<Complex>> an_enabled_feature_complex;
        Behaves_like<EnabledInDefault<Complex>> an_enabled_feature_complex_in_default;
        Behaves_like<EnabledInHeadquaters<Complex>> an_enabled_feature_complex_in_headquarters;
    }
}