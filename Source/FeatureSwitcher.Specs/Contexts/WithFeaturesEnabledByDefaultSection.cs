using Machine.Specifications;

namespace FeatureSwitcher.Specs.Contexts
{
    public class WithFeaturesEnabledByDefaultSection : WithApplicationConfiguration
    {
        Establish ctx = () => DefaultSection.FeaturesEnabled = true;
    }
}