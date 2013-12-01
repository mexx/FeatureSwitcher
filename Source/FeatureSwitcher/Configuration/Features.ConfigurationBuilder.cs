using System.Linq;

namespace FeatureSwitcher.Configuration
{
    public static partial class Features
    {
        /// <summary>
        /// Builder for feature configuration.
        /// </summary>
        public class ConfigurationBuilder : IConfigureFeatures, IConfigureNaming, IConfigureBehavior
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

            /// <summary>
            /// Gets the extension point for features configuration.
            /// </summary>
            public IConfigureFeatures And
            {
                get { return this; }
            }

            /// <summary>
            /// Gets the extension point for naming configuration.
            /// </summary>
            public IConfigureNaming NamedBy
            {
                get { return this; }
            }

            /// <summary>
            /// Gets the extension point for behavior configuration.
            /// </summary>
            public IConfigureBehavior ConfiguredBy
            {
                get { return this; }
            }

            /// <summary>
            /// Sets the specified <paramref name="namingConventions"/> into the configuration.
            /// </summary>
            /// <param name="namingConventions">The naming conventions to use.</param>
            /// <returns>the extension point for features configuration.</returns>
            public IConfigureFeatures Custom(params Feature.NamingConvention[] namingConventions)
            {
                _namingConvention = null;
                if (namingConventions != null)
                    _namingConvention = type => namingConventions.Select(x => x(type)).FirstOrDefault(x => x != null);
                return this;
            }

            /// <summary>
            /// Sets the specified <paramref name="behaviors"/> into the configuration.
            /// </summary>
            /// <param name="behaviors">The behaviors to use.</param>
            /// <returns>the extension point for features configuration.</returns>
            public IConfigureFeatures Custom(params Feature.Behavior[] behaviors)
            {
                _behavior = null;
                if (behaviors != null)
                    _behavior = feature => behaviors.Select(x => x(feature)).FirstOrDefault(x => x.HasValue);
                return this;
            }
        }
    }
}