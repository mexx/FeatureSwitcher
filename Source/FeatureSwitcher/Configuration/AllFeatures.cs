namespace FeatureSwitcher.Configuration
{
    public static class AllFeatures
    {
        public static Feature.Behavior Enabled { get; private set; }
        public static Feature.Behavior Disabled { get; private set; }

        static AllFeatures()
        {
            Enabled = name => true;
            Disabled = name => false;
        }

        public static IConfigureFeatures AlwaysEnabled(this IConfigureFeatures This)
        {
            return This.ConfiguredBy.Custom(Enabled);
        }

        public static IConfigureFeatures AlwaysDisabled(this IConfigureFeatures This)
        {
            return This.ConfiguredBy.Custom(Disabled);
        }

        public static IConfigureFeatures HandledByDefault(this IConfigureFeatures This)
        {
            return This.
                ConfiguredBy.Custom(null).And.
                NamedBy.Custom(null);
        }
    }
}