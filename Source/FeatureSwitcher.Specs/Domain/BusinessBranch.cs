using Contexteer;

namespace FeatureSwitcher.Specs.Domain
{
    public class BusinessBranch : IContext
    {
        public static readonly BusinessBranch Headquarters = new BusinessBranch();

        public static readonly BusinessBranch BranchOffice = new BusinessBranch();
    }
}