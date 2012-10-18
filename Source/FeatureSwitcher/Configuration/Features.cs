namespace FeatureSwitcher.Configuration
{
    public static partial class Features
    {
        public static IConfigureFeatures Are
        {
            get
            {
                var result = new ConfigurationBuilder(Feature.Configuration.Default);
                Feature.Configuration.Provider = result.Build;
                return result;
            }
        }

        public static IConfigureFeatures AlwaysEnabled(this IConfigureFeatures This)
        {
            return This.ConfiguredBy.Custom(OfAnyType.Enabled);
        }

        public static IConfigureFeatures AlwaysDisabled(this IConfigureFeatures This)
        {
            return This.ConfiguredBy.Custom(OfAnyType.Disabled);
        }

        public static IConfigureFeatures TypeFullName(this IConfigureNaming This)
        {
            return This.Custom(OfAnyType.NamedByTypeFullName);
        }

        public static IConfigureFeatures TypeName(this IConfigureNaming This)
        {
            return This.Custom(OfAnyType.NamedByTypeName);
        }

        public static IConfigureFeatures HandledByDefault(this IConfigureFeatures This)
        {
            return This.
                ConfiguredBy.Custom(null).And.
                NamedBy.Custom(null);
        }
    }
}