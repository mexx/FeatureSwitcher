namespace FeatureSwitcher.NamingConventions
{
    public interface IProvideFeatureNameForTypes
    {
        IProvideFeatureNames FullName { get; }
        IProvideFeatureNames Name { get; }
    }
}