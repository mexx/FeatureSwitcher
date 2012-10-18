namespace FeatureSwitcher.Configuration
{
    public static partial class Features
    {
        public static class OfAnyType
        {
            public static Feature.Behavior Enabled { get; private set; }
            public static Feature.Behavior Disabled { get; private set; }
            public static Feature.NameOf NamedByTypeName { get; private set; }
            public static Feature.NameOf NamedByTypeFullName { get; private set; }

            static OfAnyType()
            {
                Enabled = name => true;
                Disabled = name => false;
                NamedByTypeName = type => type.Name;
                NamedByTypeFullName = type => type.FullName;
            }
        }
    }
}