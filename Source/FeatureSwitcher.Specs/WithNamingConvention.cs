using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class WithShortNameNamingConvention : WithDisabledByDefaultConfiguration
    {
        Establish ctx = () => ByDefault.FeaturesAre.NamedBy.TypeName();
    }

    public class When_disabled_by_default_and_feature_explicitly_enabled_by_short_name_in_configuration_feature : WithShortNameNamingConvention
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.Name, Enabled = true });

        Behaves_like<EnabledSimpleFeatureBehavior> an_enabled_feature;
    }

    public class When_disabled_by_default_and_feature_explicitly_enabled_by_full_name_in_configuration_feature : WithShortNameNamingConvention
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.FullName, Enabled = true });

        Behaves_like<DisabledSimpleFeatureBehavior> a_disabled_feature;
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}
