using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
#pragma warning disable 169
    // ReSharper disable InconsistentNaming
    public class WithShortNameNamingConvention : WithDisabledByDefaultConfiguration
    {
        Establish ctx = () => Features.Are.NamedBy.TypeName();
    }

    public class When_disabled_by_default_and_feature_explicitly_enabled_by_short_name_in_configuration_feature : WithShortNameNamingConvention
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.Name, Enabled = true });

        Behaves_like<Enabled<Simple>> an_enabled_feature;
    }

    public class When_disabled_by_default_and_feature_explicitly_enabled_by_full_name_in_configuration_feature : WithShortNameNamingConvention
    {
        Establish ctx = () => FeaturesSection.Features.Add(new FeatureElement { Name = Simple.FullName, Enabled = true });

        Behaves_like<Disabled<Simple>> a_disabled_feature;
    }
    // ReSharper restore InconsistentNaming
#pragma warning restore 169
}
