using System;

namespace FeatureSwitcher.Configuration
{
    public static partial class Features
    {
        /// <summary>
        /// Provides common behaviors and naming conventions for features of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the feature.</typeparam>
        public static class OfType<T>
            where T: IFeature
        {
            /// <summary>
            /// Enables the feature only when it's of type <typeparamref name="T"/>.
            /// </summary>
            /// <param name="featureName">The name of the feature.</param>
            /// <returns><c>true</c> if feature is of type <typeparamref name="T"/>, <c>null</c> otherwise.</returns>
            public static bool? Enabled(Feature.Name featureName)
            {
                return typeof(T) == featureName.Type ? true : (bool?)null;
            }

            /// <summary>
            /// Disables the feature only when it's of type <typeparamref name="T"/>.
            /// </summary>
            /// <param name="featureName">The name of the feature.</param>
            /// <returns><c>false</c> if feature is of type <typeparamref name="T"/>, <c>null</c> otherwise.</returns>
            public static bool? Disabled(Feature.Name featureName)
            {
                return typeof(T) == featureName.Type ? false : (bool?)null;
            }

            /// <summary>
            /// Provides the name of the feature only if it's of type <typeparamref name="T"/>.
            /// The value of the name is the name of type <typeparamref name="T"/>.
            /// </summary>
            /// <param name="featureType">The type of the feature.</param>
            /// <returns>the name of the feature if it's of type <typeparamref name="T"/>, <c>null</c> otherwise.</returns>
            public static Feature.Name NamedByTypeName(Type featureType)
            {
                return typeof(T) == featureType ? new Feature.Name(featureType, featureType.Name) : null;
            }

            /// <summary>
            /// Provides the name of the feature only if it's of type <typeparamref name="T"/>.
            /// The value of the name is the full name of type <typeparamref name="T"/>.
            /// </summary>
            /// <param name="featureType">The type of the feature.</param>
            /// <returns>the name of the feature if it's of type <typeparamref name="T"/>, <c>null</c> otherwise.</returns>
            public static Feature.Name NamedByTypeFullName(Type featureType)
            {
                return typeof(T) == featureType ? new Feature.Name(featureType, featureType.FullName) : null;
            }
        }
    }
}