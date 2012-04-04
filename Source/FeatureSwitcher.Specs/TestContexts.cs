namespace FeatureSwitcher.Specs
{
    public class BusinessBranch : IContext
    {
        public static IContext Headquarters = new BusinessBranch();

        public static IContext BranchOffice = new BusinessBranch();
    }
}