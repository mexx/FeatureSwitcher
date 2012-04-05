using FeatureSwitcher.Behaviors.Internal;
using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class TestConfiguration : IInContextOf<BusinessBranch, IControlFeatures>, IInContextOf<BusinessBranch, IProvideNaming>
    {
        IControlFeatures IInContextOf<BusinessBranch, IControlFeatures>.With(BusinessBranch context)
        {
            return AllFeatures.Enabled;
        }

        IProvideNaming IInContextOf<BusinessBranch, IProvideNaming>.With(BusinessBranch context)
        {
            return Use.Type.Name;
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
            HandledByDefault();

        It should_not_fail = () => true.ShouldBeTrue();
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}