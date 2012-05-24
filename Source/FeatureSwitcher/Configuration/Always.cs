namespace FeatureSwitcher.Configuration
{
    public static class Always
    {
        public static IConfigureFeatures AlwaysEnabled(this IConfigureFeatures This)
        {
            return This.ConfiguredBy.Custom(AllFeatures.Enabled);
        }

        public static IConfigureFeatures AlwaysDisabled(this IConfigureFeatures This)
        {
            return This.ConfiguredBy.Custom(AllFeatures.Disabled);
        }
    }
}