using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class With_inheritance : WithCleanUp
    {
        Establish ctx = () => Features.Are.
            ConfiguredBy.Custom(TestConfigurationPartial<Complex>.Instance).And.
            NamedBy.Custom(TestConfigurationPartial<Complex>.Instance);

        Behaves_like<Enabled<Complex>> an_enabled_feature;

        Behaves_like<Enabled<IComponent, Complex>> an_enabled_feature_as_component;
    }
}