using ContextSwitcher;
using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class TestConfiguration : ISupportContextFor<IControlFeatures, BusinessBranch>
    {
        public IControlFeatures With(BusinessBranch context)
        {
            return null;
        }
    }

    public static class TestConfigurationExtensions
    {
        public static void Test(this IConfigureBehavior<BusinessBranch> This)
        {
//            This.Behavior = new TestConfiguration();
        }
    }

    public class WithMultipleContexts : WithCleanUp
    {
//        Establish ctx = () => InContexts.OfType<BusinessBranch>().FeaturesAre.ConfiguredBy.Test();

//        Cleanup cleanup = () => InContexts.OfType<BusinessBranch>().FeaturesAre.HandledByDefault();

        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;

        Behaves_like<EnabledSimpleFeatureInHeadquatersBehavior> an_enabled_feature;
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}