using System;

namespace FeatureSwitcher
{
    public static partial class Feature
    {
        /// <summary>
        /// Can control the name of the feature.
        /// </summary>
        /// <param name="featureType">The type of the feature.</param>
        /// <returns>the name of the feature, <c>null</c> if the name of the feature can't be determined.</returns>
        public delegate string NameOf(Type featureType);
    }
}