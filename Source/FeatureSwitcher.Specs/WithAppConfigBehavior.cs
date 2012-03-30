using FeatureSwitcher.Behaviors;
using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class Without_configuration_feature : WithFeature<Simple>
    {
        Establish ctx = () => ControlFeatures.Behavior = new WithAppConfig();

        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();
    }

    public class WithConfiguration<T> : WithFeature<T> where T : IFeature
    {
        protected static Section Configuration { get; private set; }

        private Establish ctx = () =>
        {
            Configuration = new Section();
            ControlFeatures.Behavior = new WithAppConfig(Configuration);
        };
    }

    public class With_default_configuration_feature : WithConfiguration<Simple>
    {
        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();
    }

    public class WithEnabledByDefaultConfiguration<T> : WithConfiguration<T> where T : IFeature
    {
        Establish ctx = () => Configuration.EnabledByDefault = true;
    }

    public class WithDisabledByDefaultConfiguration<T> : WithConfiguration<T> where T : IFeature
    {
        Establish ctx = () => Configuration.EnabledByDefault = false;
    }

    public class When_enabled_by_default_in_configuration_feature : WithEnabledByDefaultConfiguration<Simple>
    {
        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();
    }

    public class When_disabled_by_default_in_configuration_feature : WithDisabledByDefaultConfiguration<Simple>
    {
        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();
    }

    public class When_enabled_by_default_and_feature_explicitly_disabled_in_configuration_feature : WithEnabledByDefaultConfiguration<Simple>
    {
        Establish ctx = () => Configuration.Features.Add(new FeatureElement { Name = FeatureName, Enabled = false });

        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();
    }

    public class When_disabled_by_default_and_feature_explicitly_enabled_in_configuration_feature : WithDisabledByDefaultConfiguration<Simple>
    {
        Establish ctx = () => Configuration.Features.Add(new FeatureElement { Name = FeatureName, Enabled = true });

        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}
