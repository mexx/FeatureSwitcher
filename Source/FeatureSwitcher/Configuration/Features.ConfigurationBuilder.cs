using System.Linq;

namespace FeatureSwitcher.Configuration
{
    public static partial class Features
    {
        /// <summary>
        /// Builder for feature configuration.
        /// </summary>
        private class ConfigurationBuilder : IConfigureFeatures, IConfigureNaming, IConfigureBehavior
        {
            private readonly Feature.Configuration _fallback;
            private Feature.NamingConvention _namingConvention;
            private Feature.Behavior _behavior;

            /// <summary>
            /// Constructs new builder with specified <paramref name="fallback"/> configuration.
            /// </summary>
            /// <param name="fallback">The fallback configuration to use.</param>
            public ConfigurationBuilder(Feature.Configuration fallback)
            {
                _fallback = fallback;
            }

            /// <summary>
            /// Builds the configuration.
            /// </summary>
            /// <returns>the configuration.</returns>
            public Feature.Configuration Build()
            {
                return new Feature.Configuration(_namingConvention, _behavior, _fallback);
            }

            IConfigureFeatures IConfigureFeatures.And
            {
                get { return this; }
            }

            IConfigureNaming IConfigureFeatures.NamedBy
            {
                get { return this; }
            }

            IConfigureBehavior IConfigureFeatures.ConfiguredBy
            {
                get { return this; }
            }

            IConfigureFeatures IConfigureNaming.Custom(params Feature.NamingConvention[] namingConventions)
            {
                _namingConvention = null;
                if (namingConventions != null)
                    _namingConvention = type => namingConventions.Select(x => x(type)).FirstOrDefault(x => x != null);
                return this;
            }

            IConfigureFeatures IConfigureBehavior.Custom(params Feature.Behavior[] behaviors)
            {
                _behavior = null;
                if (behaviors != null)
                    _behavior = feature => behaviors.Select(x => x(feature)).FirstOrDefault(x => x.HasValue);
                return this;
            }
        }
    }
}