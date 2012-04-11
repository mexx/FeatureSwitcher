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

    public class WithMultipleContexts : WithCleanUp
    {
        Establish ctx = () => InContexts.OfType<BusinessBranch>().FeaturesAre.
            ConfiguredBy.Custom(new TestConfiguration()).And.
            NamedBy.Custom(new TestConfiguration());

        Cleanup cleanup = () => InContexts.OfType<BusinessBranch>().FeaturesAre.
            HandledByDefault();

        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;

        Behaves_like<EnabledSimpleFeatureInHeadquatersBehavior> an_enabled_feature;
    }

    public class With_multiple_contexts_unconfigured_should_fallback_to_configured_default : WithEnabledByDefaultConfiguration
    {
        Behaves_like<EnabledSimpleFeatureBehavior> an_enabled_feature;

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