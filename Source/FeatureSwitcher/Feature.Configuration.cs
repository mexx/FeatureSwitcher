using System;
using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public class Configuration
        {
            public static Configuration Default { get; private set; }
            public static Configuration Current { get { return Provider(); } }
            public static Func<Configuration> Provider { get; set; }

            static Configuration()
            {
                Default = new Configuration(Features.OfAnyType.NamedByTypeFullName, Features.OfAnyType.Disabled, null);
                Provider = () => Default;
            }

            private readonly NameOf _nameOf;
            private readonly Behavior _behavior;
            private readonly Configuration _fallback;

            public Configuration(NameOf nameOf, Behavior behavior, Configuration fallback)
            {
                _nameOf = nameOf;
                _behavior = behavior;
                _fallback = fallback;
            }

            private Configuration Fallback { get { return (_fallback ?? Default); } }

            public NameOf NamingConvention
            {
                get
                {
                    if (_nameOf == null)
                        return Fallback.NamingConvention;
                    return type => _nameOf(type) ?? Fallback.NamingConvention(type);
                }
            }

            public Behavior Behavior
            {
                get
                {
                    if (_behavior == null)
                        return Fallback.Behavior;
                    return x => _behavior(x) ?? Fallback.Behavior(x);
                }
            }

            public bool IsEnabled<TFeature>()
                where TFeature : IFeature
            {
                return Behavior(NamingConvention(typeof(TFeature))).GetValueOrDefault();
            }
        }
    }
}