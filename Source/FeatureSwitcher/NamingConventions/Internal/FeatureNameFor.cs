using System;

namespace FeatureSwitcher.NamingConventions.Internal
{
    class ProvideNaming : IProvideNaming
    {
        private readonly Func<Type, string> _nameFor;

        public ProvideNaming(Func<Type, string> nameFor)
        {
            _nameFor = nameFor;
        }

        public string For(Type feature)
        {
            return _nameFor(feature);
        }
    }
}