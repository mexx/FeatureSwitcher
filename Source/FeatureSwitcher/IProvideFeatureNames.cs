using System;

namespace FeatureSwitcher
{
    public interface IProvideFeatureNames
    {
        string For(Type feature);
    }
}