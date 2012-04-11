using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class TestConfiguration : InContextOf<BusinessBranch, IProvideBehavior>, InContextOf<BusinessBranch, IProvideNaming>
    {
        IProvideBehavior InContextOf<BusinessBranch, IProvideBehavior>.With(BusinessBranch context)
        {
            return AllFeatures.Enabled;
        }

        IProvideNaming InContextOf<BusinessBranch, IProvideNaming>.With(BusinessBranch context)
        {
            return ProvideNaming.ByTypeName;
        }
    }

    public class TestFallbackConfiguration : IProvideBehavior, IProvideNaming
    {
        public bool IsEnabled(string feature)
        {
            if (feature == typeof(Simple).Name)
                return true;

            return FeatureConfiguration.For(Context.Default).Behavior.IsEnabled(feature);
        }

        public string For<TFeature>() where TFeature : IFeature
        {
            if (typeof(TFeature) == typeof(Complex))
                return typeof(Complex).FullName;

            return FeatureConfiguration.For(Context.Default).Naming.For<TFeature>();
        }
    }

    public class WithMultipleContexts : WithCleanUp
    {
        Establish ctx = () =>
                            {
                                ByDefault.FeaturesAre.ConfiguredBy.AppConfig().IgnoreConfigurationErrors();

                                InContexts.OfType<BusinessBranch>().FeaturesAre.
                                    ConfiguredBy.Custom(new TestConfiguration()).And.
                                    NamedBy.Custom(new TestConfiguration());
                            };

        Cleanup cleanup = () => InContexts.OfType<BusinessBranch>().FeaturesAre.
                                            HandledByDefault();

        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;

        Behaves_like<EnabledSimpleFeatureInHeadquatersBehavior> an_enabled_feature_in_headquarters;
    }

    public class With_multiple_contexts_unconfigured_should_fallback_to_configured_default : WithEnabledByDefaultConfiguration
    {
        Behaves_like<EnabledSimpleFeatureBehavior> an_enabled_feature;

        Behaves_like<EnabledSimpleFeatureInHeadquatersBehavior> an_enabled_feature_in_headquarters;
    }

    public class With_multiple_contexts_unconfigured_naming_should_fallback_to_configured_default : WithCleanUp
    {
        Establish ctx = () =>
        {
            ByDefault.FeaturesAre.NamedBy.TypeName();

            InContexts.OfType<BusinessBranch>().FeaturesAre.
                ConfiguredBy.Custom(new TestFallbackConfiguration());
        };

        Cleanup cleanup = () => InContexts.OfType<BusinessBranch>().FeaturesAre.
                                            HandledByDefault();

        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;

        Behaves_like<EnabledSimpleFeatureInHeadquatersBehavior> an_enabled_feature_in_headquarters;
    }

    public class Syntax_sugar : WithCleanUp
    {
        Because of = () => ByDefault.FeaturesAre.
            NamedBy.TypeName().And.
            NamedBy.TypeFullName().And.
            ConfiguredBy.AppConfig(new DefaultSection(), new FeaturesSection()).And.
            ConfiguredBy.AppConfig(new DefaultSection(), new FeaturesSection()).IgnoreConfigurationErrors().And.
            ConfiguredBy.AppConfig(new DefaultSection(), new FeaturesSection()).IgnoreConfigurationErrors().UsingConfigSectionGroup("test").And.
            AlwaysDisabled().And.
            AlwaysEnabled().And.
            NamedBy.TypeName().
            NamedBy.TypeFullName().
            ConfiguredBy.AppConfig(new DefaultSection(), new FeaturesSection()).
            NamedBy.TypeName().
            ConfiguredBy.AppConfig(new DefaultSection(), new FeaturesSection()).IgnoreConfigurationErrors().
            ConfiguredBy.AppConfig(new DefaultSection(), new FeaturesSection()).IgnoreConfigurationErrors().UsingConfigSectionGroup("test").
            NamedBy.TypeFullName().
            AlwaysDisabled().
            AlwaysEnabled().
            HandledByDefault();

        It should_not_fail = () => true.ShouldBeTrue();
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}