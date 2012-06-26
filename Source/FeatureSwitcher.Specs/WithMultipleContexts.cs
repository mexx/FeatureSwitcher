using Contexteer;
using Contexteer.Configuration;
using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
#pragma warning disable 169
    // ReSharper disable InconsistentNaming
    public class TestConfiguration
    {
        public static IProvideBehavior Behavior(BusinessBranch context)
        {
            return AllFeatures.Enabled;
        }

        public static IProvideNaming Naming(BusinessBranch context)
        {
            return ProvideNaming.ByTypeName;
        }
    }

    public class TestFallbackConfiguration : IProvideBehavior, IProvideNaming
    {
        public bool? IsEnabled(string feature)
        {
            if (feature == typeof(Simple).Name)
                return true;

            return FeatureConfiguration.For(Default.Context).Behavior.IsEnabled(feature);
        }

        public string For<TFeature>() where TFeature : IFeature
        {
            if (typeof(TFeature) == typeof(Complex))
                return typeof(Complex).FullName;

            return FeatureConfiguration.For(Default.Context).Naming.For<TFeature>();
        }
    }

    public class PartialConfiguration : IProvideBehavior, IProvideNaming
    {
        public static readonly PartialConfiguration Instance = new PartialConfiguration();

        bool? IProvideBehavior.IsEnabled(string feature)
        {
            if (feature == null)
                return true;

            if (feature == typeof(Simple).Name)
                return true;

            return null;
        }

        string IProvideNaming.For<TFeature>()
        {
            if (typeof(TFeature) == typeof(Simple))
                return typeof(Simple).Name;
            
            return null;
        }
    }

    public class With_partial_configuration : WithCleanUp
    {
        Establish ctx = () => Features.Are.
            ConfiguredBy.Custom(PartialConfiguration.Instance).And.
            NamedBy.Custom(PartialConfiguration.Instance);

        Behaves_like<Enabled<Simple>> an_enabled_feature;

        Behaves_like<Disabled<Complex>> a_disabled_feature;
    }

    public class With_multiple_contexts : WithCleanUp
    {
        Establish ctx = () =>
        {
            Features.Are.ConfiguredBy.AppConfig().IgnoreConfigurationErrors();

            In<BusinessBranch>.Contexts.FeaturesAre().
                ConfiguredBy.Custom(TestConfiguration.Behavior).And.
                NamedBy.Custom(TestConfiguration.Naming);
        };

        Cleanup cleanup = () => In<BusinessBranch>.Contexts.FeaturesAre().
                                            HandledByDefault();

        Behaves_like<Disabled<Simple>> a_disabled_feature;

        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_feature_in_headquarters;
    }

    public class With_multiple_contexts_unconfigured_should_fallback_to_configured_default : WithEnabledByDefaultConfiguration
    {
        Behaves_like<Enabled<Simple>> an_enabled_feature;

        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_feature_in_headquarters;
    }

    public class With_multiple_contexts_unconfigured_naming_should_fallback_to_configured_default : WithCleanUp
    {
        Establish ctx = () =>
        {
            Features.Are.NamedBy.TypeName();

            In<BusinessBranch>.Contexts.FeaturesAre().
                ConfiguredBy.Custom(new TestFallbackConfiguration());
        };

        Cleanup cleanup = () => In<BusinessBranch>.Contexts.FeaturesAre().
                                            HandledByDefault();

        Behaves_like<Disabled<Simple>> a_disabled_feature;

        Behaves_like<EnabledInHeadquaters<Simple>> an_enabled_feature_in_headquarters;
    }

    // ReSharper restore InconsistentNaming
#pragma warning restore 169
}