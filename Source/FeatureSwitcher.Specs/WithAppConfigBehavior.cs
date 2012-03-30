using FeatureSwitcher.Behaviors;
using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class Without_configuration_feature : WithFeature<Simple>
    {
        Establish ctx = () => ControlFeatures.Behavior = new WithAppConfig(true);

        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();
    }

    public class WithConfiguration<T> : WithFeature<T> where T : IFeature
    {
        protected static DefaultSection DefaultSection { get; private set; }
        protected static FeaturesSection FeaturesSection { get; private set; }

        private Establish ctx = () =>        
        {
            DefaultSection = new DefaultSection();
            FeaturesSection = new FeaturesSection();
            ControlFeatures.Behavior = new WithAppConfig(DefaultSection, FeaturesSection);
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
    }

    public class When_disabled_by_default_in_configuration_feature : WithDisabledByDefaultConfiguration<Simple>
    {
        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();
    }

    public class When_enabled_by_default_and_feature_explicitly_disabled_in_configuration_feature : WithEnabledByDefaultConfiguration<Simple>
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.Name, Enabled = false });

        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();
    }

    public class When_disabled_by_default_and_feature_explicitly_enabled_in_configuration_feature : WithDisabledByDefaultConfiguration<Simple>
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.Name, Enabled = true });

        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();
    }

    public class When_enabled_by_default_and_feature_not_explicitly_disabled_in_configuration_feature : WithEnabledByDefaultConfiguration<Complex>
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.Name, Enabled = false });

        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();
    }

    public class When_disabled_by_default_and_feature_not_explicitly_enabled_in_configuration_feature : WithDisabledByDefaultConfiguration<Complex>
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.Name, Enabled = true });

        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}
