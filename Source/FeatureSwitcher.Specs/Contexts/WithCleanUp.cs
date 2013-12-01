using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs.Contexts
{
    public class WithCleanUp
    {
        Cleanup clean = () => Features.Are.HandledByDefault();
    }
}