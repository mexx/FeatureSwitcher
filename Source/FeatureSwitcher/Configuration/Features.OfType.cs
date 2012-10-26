namespace FeatureSwitcher.Configuration
{
    public static partial class Features
    {
        /// <summary>
        /// Provides common behaviors and naming conventions for feature of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the feature.</typeparam>
        public static class OfType<T>
            where T: IFeature
        {
            /// <summary>
            /// Gets the behavior which enables the feature when its name matches the name of type <typeparamref name="T"/>.
            /// </summary>
            public static Feature.Behavior EnabledByTypeName { get; private set; }
            /// <summary>
            /// Gets the behavior which enables the feature when its name matches the full name of type <typeparamref name="T"/>.
            /// </summary>
            public static Feature.Behavior EnabledByTypeFullName { get; private set; }
            /// <summary>
            /// Gets the behavior which disables the feature when its name matches the name of type <typeparamref name="T"/>.
            /// </summary>
            public static Feature.Behavior DisabledByTypeName { get; private set; }
            /// <summary>
            /// Gets the behavior which disables the feature when its name matches the full name of type <typeparamref name="T"/>.
            /// </summary>
            public static Feature.Behavior DisabledByTypeFullName { get; private set; }
            /// <summary>
            /// Gets the naming convention which applies only to features of type <typeparamref name="T"/> and names it by the name of type <typeparamref name="T"/>.
            /// </summary>
            public static Feature.NameOf NamedByTypeName { get; private set; }
            /// <summary>
            /// Gets the naming convention which applies only to features of type <typeparamref name="T"/> and names it by the full name of type <typeparamref name="T"/>.
            /// </summary>
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