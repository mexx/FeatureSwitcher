namespace FeatureSwitcher.Configuration
{
    public static partial class Features
    {
        /// <summary>
        /// Provides common behaviors and naming conventions for any type.
        /// </summary>
        public static class OfAnyType
        {
            /// <summary>
            /// Gets the behavior which enables any feature.
            /// </summary>
            public static Feature.Behavior Enabled { get; private set; }
            /// <summary>
            /// Gets the behavior which disables any feature.
            /// </summary>
            public static Feature.Behavior Disabled { get; private set; }
            /// <summary>
            /// Gets the naming convention which names any feature by name of the type.
            /// </summary>
            public static Feature.NameOf NamedByTypeName { get; private set; }
            /// <summary>
            /// Gets the naming convention which names any feature by full name of the type.
            /// </summary>
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