using System;
using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
#pragma warning disable 169
    // ReSharper disable InconsistentNaming
    public class Without_configuration : WithCleanUp
    {
        Establish ctx = () => Features.Are.ConfiguredBy.AppConfig();

        // ReSharper disable UnusedVariable
        Because of = () => _exception = Catch.Exception(() => { var isEnabled=Feature<Simple>.Is().Enabled; });
        // ReSharper restore UnusedVariable

        It should_throw_a_configuration_errors_exception = () => _exception.ShouldBeOfType<System.Configuration.ConfigurationErrorsException>();

        private static Exception _exception;
    }

    public class Without_configuration_feature : WithCleanUp
    {
        Establish ctx = () => Features.Are.ConfiguredBy.AppConfig().IgnoreConfigurationErrors();

        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;
    }

    public class WithConfiguration : WithCleanUp
    {
        protected static DefaultSection DefaultSection { get; private set; }
        protected static FeaturesSection FeaturesSection { get; private set; }

        Establish ctx = () =>        
        {
            DefaultSection = new DefaultSection();
            FeaturesSection = new FeaturesSection();
            Features.Are.ConfiguredBy.AppConfig(DefaultSection, FeaturesSection);
        };
    }

    public class With_default_configuration_feature : WithConfiguration
    {
        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;
    }

    public class WithEnabledByDefaultConfiguration : WithConfiguration
    {
        Establish ctx = () => DefaultSection.FeaturesEnabled = true;
    }

    public class WithDisabledByDefaultConfiguration : WithConfiguration
    {
        Establish ctx = () => DefaultSection.FeaturesEnabled = false;
    }

    public class When_enabled_by_default_in_configuration_feature : WithEnabledByDefaultConfiguration
    {
        Behaves_like<EnabledSimpleFeatureBehavior> an_enabled_feature;
    }

    public class When_disabled_by_default_in_configuration_feature : WithDisabledByDefaultConfiguration
    {
        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;
    }

    public class When_enabled_by_default_and_feature_explicitly_disabled_in_configuration_feature : WithEnabledByDefaultConfiguration
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.FullName, Enabled = false });

        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;
    }

    public class When_disabled_by_default_and_feature_explicitly_enabled_in_configuration_feature : WithDisabledByDefaultConfiguration
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.FullName, Enabled = true });

        Behaves_like<EnabledSimpleFeatureBehavior> an_enabled_feature;
    }

    public class When_enabled_by_default_and_feature_not_explicitly_disabled_in_configuration_feature : WithEnabledByDefaultConfiguration
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Complex.FullName, Enabled = false });

        Behaves_like<EnabledSimpleFeatureBehavior> an_enabled_feature;
    }

    public class When_disabled_by_default_and_feature_not_explicitly_enabled_in_configuration_feature : WithDisabledByDefaultConfiguration
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Complex.FullName, Enabled = true });

        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;
    }
    // ReSharper restore InconsistentNaming
#pragma warning restore 169
}