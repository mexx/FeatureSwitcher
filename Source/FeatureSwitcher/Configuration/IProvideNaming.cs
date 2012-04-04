using System;

namespace FeatureSwitcher
{
    public interface IProvideNaming
    {
        string For(Type feature);
    }
}