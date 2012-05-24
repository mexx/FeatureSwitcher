namespace FeatureSwitcher.Configuration
{
    public static class Named
    {
        public static IConfigureFeatures TypeFullName(this IConfigureNaming This)
        {
            return This.Custom(ProvideNaming.ByTypeFullName);
        }

        public static IConfigureFeatures TypeName(this IConfigureNaming This)
        {
            return This.Custom(ProvideNaming.ByTypeName);
        }
    }
}