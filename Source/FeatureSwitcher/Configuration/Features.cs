using System.Linq;

namespace FeatureSwitcher.Configuration
{
    public static class Features
    {
        public static IConfigureFeatures Are
        {
            get
            {
                var result = new FeaturesAre(Feature.Configuration.Default);
                Feature.Configuration.Provider = () => result.Configuration;
                return result;
            }
        }

        public class FeaturesAre : IConfigureFeatures, IConfigureNaming, IConfigureBehavior
        {
            private readonly Feature.Configuration _fallback;
            private Feature.NameOf _nameOf;
            private Feature.Behavior _behavior;

            public FeaturesAre(Feature.Configuration fallback)
            {
                _fallback = fallback;
            }

            public Feature.Configuration Configuration
            {
                get { return new Feature.Configuration(_nameOf, _behavior, _fallback); }
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

            IConfigureFeatures IConfigureNaming.Custom(params Feature.NameOf[] nameOfs)
            {
                _nameOf = null;
                if (nameOfs != null)
                    _nameOf = type => nameOfs.Select(x => x(type)).FirstOrDefault(x => x != null);
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