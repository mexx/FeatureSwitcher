using System;

namespace FeatureSwitcher.NamingConventions.Internal
{
    class ProvideFeatureName : IProvideFeatureNames
    {
        private readonly Func<Type, string> _nameFor;

        public ProvideFeatureName(Func<Type, string> nameFor)
        {
            _nameFor = nameFor;
        }

        public string For(Type feature)
        {
            return _nameFor(feature);
        }
    }
}