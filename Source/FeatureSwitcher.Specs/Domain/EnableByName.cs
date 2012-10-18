using System;
using FeatureSwitcher.Configuration;

namespace FeatureSwitcher.Specs.Domain
{
    public class EnableByName<T> 
        where T : IFeature
    {
        public readonly static EnableByName<T> Instance = new EnableByName<T>();

        public bool? IsEnabled(string feature)
        {
            return Features.OfType<T>.EnabledByTypeName(feature);
        }

        public string For(Type featureType)
        {
            return Features.OfType<T>.NamedByTypeName(featureType);
        }
    }
}