namespace FeatureSwitcher.Configuration
{
    public static class Defaults
    {
        public static void HandledByDefault(this IConfigureFeatures This)
        {
            This.ConfiguredBy.Custom(null);
            This.NamedBy.Custom(null);
        }
    }
}