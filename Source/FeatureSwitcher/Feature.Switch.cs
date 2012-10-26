using System;
using System.Reflection;

namespace FeatureSwitcher
{
    public static partial class Feature
    {
        /// <summary>
        /// Groups switch related functionality.
        /// </summary>
        public static partial class Switch
        {
            private static readonly MethodInfo ForMethod;

            static Switch()
            {
                ForMethod = typeof(Switch).GetMethod("For", new Type[0]);
            }

            /// <summary>
            /// Provides the switch for features of type <typeparamref name="T"/>.
            /// </summary>
            /// <typeparam name="T">The type of the feature.</typeparam>
            /// <returns>the switch for features of type <typeparamref name="T"/>.</returns>
            public static IAmFor<T> For<T>()
                where T : IFeature
            {
                return new Of<T>();
            }

            /// <summary>
            /// Provides the switch for features of type <typeparamref name="T"/>.
            /// </summary>
            /// <typeparam name="T">The type of the feature.</typeparam>
            /// <param name="featureType">The concrete type of the feature.</param>
            /// <returns>the switch for features of type <typeparamref name="T"/>.</returns>
            public static IAmFor<T> For<T>(Type featureType)
                where T : IFeature
            {
                return (IAmFor<T>)ForMethod.MakeGenericMethod(new[] { featureType }).Invoke(null, new object[0]);
            }
        }
    }
}