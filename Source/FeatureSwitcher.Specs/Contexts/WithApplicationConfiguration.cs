using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs.Contexts
{
    public class WithApplicationConfiguration : WithCleanUp
    {
        protected static DefaultSection DefaultSection { get; private set; }
        protected static FeaturesSection FeaturesSection { get; private set; }

        Establish ctx = () =>
        {
            DefaultSection = new DefaultSection();
            FeaturesSection = new FeaturesSection();
            var appConfig = new AppConfig(DefaultSection, FeaturesSection);
            Features.Are.
                ConfiguredBy.Custom(appConfig.Features, appConfig.Default);
        };
    }
}