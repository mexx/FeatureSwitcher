using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class WithCleanUp
    {
        Cleanup clean = () =>
                            {
                                ControlFeatures.Behavior = null;
                                ControlFeatures.Name = null;
                            };
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}