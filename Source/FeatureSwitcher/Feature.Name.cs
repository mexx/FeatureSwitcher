using System;

namespace FeatureSwitcher
{
    public static partial class Feature
    {
        /// <summary>
        /// Represents the name of the feature.
        /// </summary>
        public class Name
        {
            /// <summary>
            /// Constructs new feature name with specified <paramref name="type"/> and <paramref name="value"/>.
            /// </summary>
            /// <param name="type">The type of the feature.</param>
            /// <param name="value">The name determined by the naming convention.</param>
            public Name(Type type, string value)
            {
                Type = type;
                Value = value;
            }

            /// <summary>
            /// Gets the type of the feature.
            /// </summary>
            public Type Type { get; private set; }

            /// <summary>
            /// Gets the name of the feature determined by the naming convention.
            /// </summary>
            public string Value { get; private set; }
        }
    }
}