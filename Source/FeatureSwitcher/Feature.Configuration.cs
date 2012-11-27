using System;
using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public static partial class Feature
    {
        /// <summary>
        /// Provides the configuration for feature switches.
        /// </summary>
        public class Configuration
        {
            /// <summary>
            /// Gets the default configuration, where all features are named by full name of the type and disabled.
            /// </summary>
            public static Configuration Default { get; private set; }
            /// <summary>
            /// Gets the current configuration.
            /// </summary>
            public static Configuration Current { get { return Provider(); } }
            /// <summary>
            /// Gets and sets the function to use to determine the current configuration.
            /// </summary>
            public static Func<Configuration> Provider { get; set; }

            static Configuration()
            {
                Default = new Configuration(Features.OfAnyType.NamedByTypeFullName, Features.OfAnyType.Disabled, null);
                Provider = () => Default;
            }

            private readonly NamingConvention _namingConvention;
            private readonly Behavior _behavior;
            private readonly Configuration _fallback;

            /// <summary>
            /// Constructs a configuration for feature switches.
            /// </summary>
            /// <param name="namingConvention">The naming convention to use.</param>
            /// <param name="behavior">The behavior to use.</param>
            /// <param name="fallback">The fallback configuration to use.</param>
            public Configuration(NamingConvention namingConvention, Behavior behavior, Configuration fallback)
            {
                _namingConvention = namingConvention;
                _behavior = behavior;
                _fallback = fallback;
            }

            private Configuration Fallback { get { return (_fallback ?? Default); } }

            /// <summary>
            /// Gets the naming convention for this configuration.
            /// </summary>
            public NamingConvention NamingConvention
            {
                get
                {
                    if (_namingConvention == null)
                        return Fallback.NamingConvention;
                    return type => _namingConvention(type) ?? Fallback.NamingConvention(type);
                }
            }

            /// <summary>
            /// Gets the behavior for this configuration.
            /// </summary>
            public Behavior Behavior
            {
                get
                {
                    if (_behavior == null)
                        return Fallback.Behavior;
                    return x => _behavior(x) ?? Fallback.Behavior(x);
                }
            }

            /// <summary>
            /// Determines whether the <typeparamref name="TFeature"/> is enabled or disabled.
            /// </summary>
            /// <typeparam name="TFeature">The type of the feature.</typeparam>
            /// <returns><c>true</c> if feature is enabled, <c>false</c> if not.</returns>
            public bool IsEnabled<TFeature>()
                where TFeature : IFeature
            {
                return Behavior(NamingConvention(typeof(TFeature))).GetValueOrDefault();
            }
        }
    }
}