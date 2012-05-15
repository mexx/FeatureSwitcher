using System;

namespace FeatureSwitcher.Configuration
{
    public sealed class ProvideNaming : IProvideNaming
    {
        public static IProvideNaming ByTypeName { get; private set; }
        public static IProvideNaming ByTypeFullName { get; private set; }

        static ProvideNaming()
        {
            ByTypeFullName = new ProvideNaming(x => x.FullName);
            ByTypeName = new ProvideNaming(x => x.Name);
        }

        private readonly Func<Type, string> _nameFor;

        private ProvideNaming(Func<Type, string> nameFor)
        {
            _nameFor = nameFor;
        }

        public string For<TFeature>() where TFeature : IFeature
        {
            return _nameFor(typeof(TFeature));
        }
    }
}