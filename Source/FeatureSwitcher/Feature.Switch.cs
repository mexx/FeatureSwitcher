using System;
using System.Reflection;

namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public static partial class Switch
        {
            private static readonly MethodInfo ForMethod;

            static Switch()
            {
                ForMethod = typeof(Switch).GetMethod("For", new Type[0]);
            }

            public static IAmFor<T> For<T>()
                where T : IFeature
            {
                return new Of<T>();
            }

            public static IAmFor<T> For<T>(Type featureType)
                where T : IFeature
            {
                return (IAmFor<T>)ForMethod.MakeGenericMethod(new[] { featureType }).Invoke(null, new object[0]);
            }
        }
    }
}