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
    // ReSharper restore InconsistentNaming
#pragma warning restore 169
}