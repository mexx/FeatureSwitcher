using System;

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
            /// Enables any feature.
            /// </summary>
            /// <param name="featureName">The name of the feature.</param>
            /// <returns>always <c>true</c>.</returns>
            public static bool? Enabled(Feature.Name featureName)
            {
                return true;
            }

            /// <summary>
            /// Disables any feature.
            /// </summary>
            /// <param name="featureName">The name of the feature.</param>
            /// <returns>always <c>false</c>.</returns>
            public static bool? Disabled(Feature.Name featureName)
            {
                return false;
            }

            /// <summary>
            /// Provides the name of the feature.
            /// The value of the name is the name of <paramref name="featureType"/>.
            /// </summary>
            /// <param name="featureType">The type of the feature.</param>
            /// <returns>the name of the feature.</returns>
            public static Feature.Name NamedByTypeName(Type featureType)
            {
                return new Feature.Name(featureType, featureType.Name);
            }

            /// <summary>
            /// Provides the name of the feature.
            /// The value of the name is the full name of <paramref name="featureType"/>.
            /// </summary>
            /// <param name="featureType">The type of the feature.</param>
            /// <returns>the name of the feature.</returns>
            public static Feature.Name NamedByTypeFullName(Type featureType)
            {
                return new Feature.Name(featureType, featureType.FullName);
            }
        }
    }
}