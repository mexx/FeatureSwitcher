namespace FeatureSwitcher.Configuration
{
    public static class Named
    {
        public static Feature.NameOf ByFullName { get; private set; }
        public static Feature.NameOf ByName { get; private set; }

        static Named()
        {
            ByFullName = featureType => featureType.FullName;
            ByName = type => type.Name;
        }

        public static IConfigureFeatures TypeFullName(this IConfigureNaming This)
        {
            return This.Custom(ByFullName);
        }

        public static IConfigureFeatures TypeName(this IConfigureNaming This)
        {
            return This.Custom(ByName);
        }
    }
}