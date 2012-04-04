using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class WithMultipleContexts : WithCleanUp
    {
        Establish ctx = () => Use.Context[BusinessBranch.Headquarters].WithFeatures.AlwaysEnabled();

        Cleanup cleanup = () => Use.Context[BusinessBranch.Headquarters].WithFeatures.AlwaysDisabled();

        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;

        Behaves_like<EnabledSimpleFeatureInHeadquatersBehavior> an_enabled_feature;
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}