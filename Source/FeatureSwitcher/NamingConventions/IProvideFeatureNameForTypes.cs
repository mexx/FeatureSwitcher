namespace FeatureSwitcher.NamingConventions
{
    public interface IProvideFeatureNameForTypes
    {
        IProvideNaming FullName { get; }
        IProvideNaming Name { get; }
    }
}