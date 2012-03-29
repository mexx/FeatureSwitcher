using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class WithFeature
    {
        protected static bool _featureEnabled;

        Cleanup clean = () => ControlFeatures.Behavior = null;

        Because of = () => _featureEnabled = Feature<Sample>.IsEnabled;
    }

    public class Without_configuration_feature : WithFeature
    {
        Establish ctx = () => ControlFeatures.Behavior = new WithAppConfig();

        It should_be_disabled = () => _featureEnabled.ShouldBeFalse();
    }

    public class With_default_configuration_feature : WithFeature
    {
        Establish ctx = () => ControlFeatures.Behavior = new WithAppConfig(new Configuration.Configuration());

        It should_be_disabled = () => _featureEnabled.ShouldBeFalse();
    }

    public class When_enabled_by_default_in_configuration_feature : WithFeature
    {
        Establish ctx = () => ControlFeatures.Behavior = new WithAppConfig(new Configuration.Configuration { EnabledByDefault = true });

        It should_be_enabled = () => _featureEnabled.ShouldBeTrue();
    }

    public class When_disabled_by_default_in_configuration_feature : WithFeature
    {
        Establish ctx = () => ControlFeatures.Behavior = new WithAppConfig(new Configuration.Configuration { EnabledByDefault = false });

        It should_be_disabled = () => _featureEnabled.ShouldBeFalse();
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}
