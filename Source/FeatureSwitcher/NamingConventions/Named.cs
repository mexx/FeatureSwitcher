using System;

namespace FeatureSwitcher.Configuration
{
    public static class Named
    {
        public static IFeatureConfiguration TypeFullName(this IConfigureNaming This)
        {
            This.Naming = Use.Type.FullName;
            return null;
        }

        public static IFeatureConfiguration TypeName(this IConfigureNaming This)
        {
            This.Naming = Use.Type.Name;
            return null;
        }
    }
}