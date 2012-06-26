using Contexteer;
using Contexteer.Configuration;
using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
#pragma warning disable 169
    // ReSharper disable InconsistentNaming
    public class WithCleanUp
    {
        Cleanup clean = () => Features.Are.HandledByDefault();
    }

    public class WithContextCleanUp : WithCleanUp
    {
        Cleanup cleanup = () =>
        {
            In<Default>.Contexts.FeaturesAre().HandledByDefault();
            In<BusinessBranch>.Contexts.FeaturesAre().HandledByDefault();
        };
    }
    // ReSharper restore InconsistentNaming
#pragma warning restore 169
}