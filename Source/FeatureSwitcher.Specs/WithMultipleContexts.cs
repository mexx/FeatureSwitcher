using Contexteer;
using Contexteer.Configuration;
using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
#pragma warning disable 169
    // ReSharper disable InconsistentNaming
    public class With_partial_configuration : WithCleanUp
    {
        Establish ctx = () => Features.Are.
            ConfiguredBy.Custom(TestConfigurationPartial<Simple>.Instance).And.
            NamedBy.Custom(TestConfigurationPartial<Simple>.Instance);

        Behaves_like<Enabled<Simple>> an_enabled_feature;

        Behaves_like<Disabled<Complex>> a_disabled_feature;
    }

    public class WithContextCleanUp : WithCleanUp
    {
        Cleanup cleanup = () =>
        {
            In<Default>.Contexts.FeaturesAre().HandledByDefault();
            In<BusinessBranch>.Contexts.FeaturesAre().HandledByDefault();
        };
    }

    public class With_partial_configuration_and_contexts : WithContextCleanUp
    {
        Establish ctx = () =>
        {
            Features.Are.
                ConfiguredBy.Custom(TestConfigurationPartial<Simple>.Instance).And.
                NamedBy.Custom(TestConfigurationPartial<Simple>.Instance);

            In<Default>.Contexts.FeaturesAre().
                ConfiguredBy.Custom(TestConfigurationPartial<Basic>.Instance).And.
                NamedBy.Custom(TestConfigurationPartial<Basic>.Instance);

            In<BusinessBranch>.Contexts.FeaturesAre().
                ConfiguredBy.Custom(TestConfigurationPartial<Complex>.Instance).And.
                NamedBy.Custom(TestConfigurationPartial<Complex>.Instance);            
        };

        Behaves_like<Enabled<Simple>> an_enabled_feature_simple;

        Behaves_like<EnabledInDefault<Simple>> an_enabled_feature_simple_in_default;

        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_feature_simple_in_headquarters;

        Behaves_like<Disabled<Basic>> a_disabled_feature_basic;

        Behaves_like<EnabledInDefault<Basic>> an_enabled_feature_basic_in_default;

        Behaves_like<EnabledInHeadquaters<Basic>> an_enabled_feature_basic_in_headquarters;

        Behaves_like<Disabled<Complex>> a_disabled_feature_complex;

        Behaves_like<DisabledInDefault<Complex>> an_enabled_feature_complex_in_default;

        Behaves_like<EnabledInHeadquaters<Complex>> an_enabled_feature_complex_in_headquarters;
    }
    
    public class With_multiple_contexts_unconfigured_should_fallback_to_configured_default : WithEnabledByDefaultConfiguration
    {
        Behaves_like<Enabled<Simple>> an_enabled_feature;

        Behaves_like<EnabledInDefault<Simple>> an_enabled_feature_in_default;

        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_feature_in_headquarters;
    }

    public class With_multiple_contexts_unconfigured_naming_should_fallback_to_configured_default : WithContextCleanUp
    {
        Establish ctx = () =>
        {
            Features.Are.NamedBy.TypeName();

            In<BusinessBranch>.Contexts.FeaturesAre().
                ConfiguredBy.Custom(TestConfigurationPartial<Simple>.Instance);
        };

        Behaves_like<Disabled<Simple>> a_disabled_feature;

        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_feature_in_headquarters;
    }
    // ReSharper restore InconsistentNaming
#pragma warning restore 169
}