namespace FeatureSwitcher.Specs.Domain
{
    public static class EnableByName<T>
        where T : IFeature
    {
        public static bool? IsEnabled(Feature.Name name)
        {
            return typeof(T).Name == name.Value ? true : (bool?)null;
        }
    }
}