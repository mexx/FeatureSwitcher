using System;
using FeatureSwitcher.Behaviors.Internal;
using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class Without_configuration
    {
        Establish ctx = () => ControlFeatures.Behavior = Use.SettingsFrom.AppConfig();

        Cleanup clean = () => ControlFeatures.Behavior = null;

        Because of = () => _exception = Catch.Exception(() => { var isEnabled=Feature<Simple>.IsEnabled; });

        It should_throw_a_configuration_errors_exception = () => _exception.ShouldBeOfType<System.Configuration.ConfigurationErrorsException>();

        private static Exception _exception;
    }

    public class Without_configuration_feature : WithFeature<Simple>
    {
        Establish ctx = () => ControlFeatures.Behavior = Use.SettingsFrom.AppConfig().IgnoreConfigurationErrors();

        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }

    public class WithConfiguration<T> : WithFeature<T> where T : IFeature
    {
        protected static DefaultSection DefaultSection { get; private set; }
        protected static FeaturesSection FeaturesSection { get; private set; }

        Establish ctx = () =>        
        {
            DefaultSection = new DefaultSection();
            FeaturesSection = new FeaturesSection();
            ControlFeatures.Behavior = new AppConfig(DefaultSection, FeaturesSection);
        };
    }

    public class With_default_configuration_feature : WithConfiguration<Simple>
    {
        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();
    }

    public class WithEnabledByDefaultConfiguration<T> : WithConfiguration<T> where T : IFeature
    {
        Establish ctx = () => DefaultSection.FeaturesEnabled = true;
    }

    public class WithDisabledByDefaultConfiguration<T> : WithConfiguration<T> where T : IFeature
    {
        Establish ctx = () => DefaultSection.FeaturesEnabled = false;
    }

    public class When_enabled_by_default_in_configuration_feature : WithEnabledByDefaultConfiguration<Simple>
    {
        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }

    public class When_disabled_by_default_in_configuration_feature : WithDisabledByDefaultConfiguration<Simple>
    {
        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }

    public class When_enabled_by_default_and_feature_explicitly_disabled_in_configuration_feature : WithEnabledByDefaultConfiguration<Simple>
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.FullName, Enabled = false });

        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }

    public class When_disabled_by_default_and_feature_explicitly_enabled_in_configuration_feature : WithDisabledByDefaultConfiguration<Simple>
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.FullName, Enabled = true });

        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }

    public class When_enabled_by_default_and_feature_not_explicitly_disabled_in_configuration_feature : WithEnabledByDefaultConfiguration<Simple>
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Complex.FullName, Enabled = false });

        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }

    public class When_disabled_by_default_and_feature_not_explicitly_enabled_in_configuration_feature : WithDisabledByDefaultConfiguration<Simple>
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Complex.FullName, Enabled = true });

        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}
