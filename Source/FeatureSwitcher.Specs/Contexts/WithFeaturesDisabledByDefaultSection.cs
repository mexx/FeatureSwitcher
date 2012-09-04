using Machine.Specifications;

namespace FeatureSwitcher.Specs.Contexts
{
    public class WithFeaturesDisabledByDefaultSection : WithApplicationConfiguration
    {
        Establish ctx = () => DefaultSection.FeaturesEnabled = false;
    }
}