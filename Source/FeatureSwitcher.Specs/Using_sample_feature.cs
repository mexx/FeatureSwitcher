using System;
using Machine.Fakes;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class Sample : IFeature { }

    public class When_no_behavior_configured_sample_feature
    {
        static bool _isEnabled;

        Because of = () => _isEnabled = Feature<Sample>.IsEnabled;

        It should_be_disabled = () => _isEnabled.ShouldBeFalse();
    }

    public class WithAllFeaturesAreEnabled : WithFakes
    {
        Establish ctx = () =>
        {
            var behavior = An<IControlFeatures>();
            behavior.
                WhenToldTo(x => x.IsEnabled(Param.IsAny<Type>())).
                Return(true);

            ControlFeatures.Behavior = behavior;
        };

        Cleanup clean = () => ControlFeatures.Behavior = null;
    }

    public class WithAllFeaturesAreDisabled : WithFakes
    {
        Establish ctx = () =>
        {
            var behavior = An<IControlFeatures>();
            //behavior.
            //    WhenToldTo(x => x.IsEnabled(Param.IsAny<Type>())).
            //    Return(false);

            ControlFeatures.Behavior = behavior;
        };

        Cleanup clean = () => ControlFeatures.Behavior = null;
    }

    public class When_all_features_are_enabled_sample_feature : WithAllFeaturesAreEnabled
    {
        static bool _featureEnabled;

        Because of = () => _featureEnabled = Feature<Sample>.IsEnabled;

        It should_be_enabled = () => _featureEnabled.ShouldBeTrue();
    }

    public class When_all_features_are_disabled_sample_feature : WithAllFeaturesAreDisabled
    {
        static bool _featureEnabled;

        Because of = () => _featureEnabled = Feature<Sample>.IsEnabled;

        It should_be_disabled = () => _featureEnabled.ShouldBeFalse();
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}