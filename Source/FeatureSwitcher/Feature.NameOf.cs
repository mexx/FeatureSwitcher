using System;

namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public delegate string NameOf(Type featureType);
    }
}