namespace FeatureSwitcher.Configuration
{
    public static class Defaults
    {
        public static IConfigureFeatures HandledByDefault(this IConfigureFeatures This)
        {
            return This.
                ConfiguredBy.Custom(null).And.
                NamedBy.Custom(null);
        }
    }
}