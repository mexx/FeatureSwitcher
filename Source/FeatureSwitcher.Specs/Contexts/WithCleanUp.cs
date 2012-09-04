using Contexteer;
using Contexteer.Configuration;
using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs.Contexts
{
    public class WithCleanUp
    {
        Cleanup clean = () =>
                            {
                                Features.Are.HandledByDefault();
                                In<Default>.Contexts.FeaturesAre().HandledByDefault();
                                In<BusinessBranch>.Contexts.FeaturesAre().HandledByDefault();
                            };
    }
}