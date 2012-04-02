using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class WithShortNameNamingConvention<T> : WithDisabledByDefaultConfiguration<T> where T : IFeature
    {
        Establish ctx = () => ControlFeatures.Name = Use.Type.Name;
    }

    public class When_disabled_by_default_and_feature_explicitly_enabled_by_short_name_in_configuration_feature : WithShortNameNamingConvention<Simple>
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.Name, Enabled = true });

        It should_be_enabled = () => FeatureEnabled.ShouldBeTrue();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }

    public class When_disabled_by_default_and_feature_explicitly_enabled_by_full_name_in_configuration_feature : WithShortNameNamingConvention<Simple>
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.FullName, Enabled = true });

        It should_be_disabled = () => FeatureEnabled.ShouldBeFalse();

        It should_be_same_state_as_non_generic = () => FeatureEnabled.ShouldEqual(new Simple().IsEnabled());
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}
