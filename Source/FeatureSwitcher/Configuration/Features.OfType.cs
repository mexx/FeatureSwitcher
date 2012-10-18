namespace FeatureSwitcher.Configuration
{
    public static partial class Features
    {
        public static class OfType<T>
            where T: IFeature
        {
            public static Feature.Behavior EnabledByTypeName { get; private set; }
            public static Feature.Behavior EnabledByTypeFullName { get; private set; }
            public static Feature.Behavior DisabledByTypeName { get; private set; }
            public static Feature.Behavior DisabledByTypeFullName { get; private set; }
            public static Feature.NameOf NamedByTypeName { get; private set; }
            public static Feature.NameOf NamedByTypeFullName { get; private set; }

            static OfType()
            {
                var featureType = typeof (T);
                EnabledByTypeName = name => featureType.Name == name ? true : (bool?) null;
                EnabledByTypeFullName = name => featureType.FullName == name ? true : (bool?) null;
                DisabledByTypeName = name => featureType.Name != name ? true : (bool?) null;
                DisabledByTypeFullName = name => featureType.FullName != name ? true : (bool?) null;
                NamedByTypeName = type => featureType == type ? type.Name : null;
                NamedByTypeFullName = type => featureType == type ? type.FullName : null;
            }
        }
    }
}