using FeatureSwitcher.Configuration;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class WithCleanUp
    {
        Cleanup clean = () =>
                            {
                                ByDefault.FeaturesAre.AlwaysDisabled();
                                ByDefault.FeaturesAre.NamedBy.TypeFullName();
                            };
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}