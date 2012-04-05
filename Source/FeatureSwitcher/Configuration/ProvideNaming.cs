using System;

namespace FeatureSwitcher.Configuration
{
    public sealed class ProvideNaming : IProvideNaming
    {
        private readonly Func<Type, string> _nameFor;

        public static readonly IProvideNaming ByTypeName = new ProvideNaming(x => x.Name);
        public static readonly IProvideNaming ByTypeFullName = new ProvideNaming(x => x.FullName);

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