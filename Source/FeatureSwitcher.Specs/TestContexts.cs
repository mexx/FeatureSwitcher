using ContextSwitcher;

namespace FeatureSwitcher.Specs
{
    public class BusinessBranch : IContext
    {
        public static BusinessBranch Headquarters = new BusinessBranch();

        public static BusinessBranch BranchOffice = new BusinessBranch();
    }
}