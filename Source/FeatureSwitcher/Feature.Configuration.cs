using System;
using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public class Configuration : IProvideState
        {
            private readonly IProvideState _provideState;
            public static Configuration Default { get; private set; }
            public static Configuration Current { get { return Provider(); } }
            public static Func<Configuration> Provider { get; set; }

            static Configuration()
            {
                Default = new Configuration();
                Provider = () => Default;
            }

            public Configuration()
                : this(null)
            {
            }

            public Configuration(IProvideState provideState)
            {
                _provideState = provideState;
            }

            public IProvideState ProvideState { get { return _provideState ?? FeatureSwitcher.Configuration.ProvideState.Control; } }
            
            public bool IsEnabled<TFeature>() 
                where TFeature : IFeature
            {
                return ProvideState.IsEnabled<TFeature>();
            }
        }
    }
}