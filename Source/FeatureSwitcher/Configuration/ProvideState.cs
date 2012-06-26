using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureSwitcher.Configuration
{
    public sealed class ProvideState : IProvideState
    {
        internal static IProvideBehavior ConfiguredBehavior { get; set; }
        internal static IProvideNaming ConfiguredNaming { get; set; }

        internal static ProvideState Control
        {
            get { return new ProvideState(new IProvideBehavior[0], new IProvideNaming[0]); }
        }

        private readonly IEnumerable<IProvideBehavior> _behaviors;
        private readonly IEnumerable<IProvideNaming> _namings;

        public ProvideState(IEnumerable<IProvideBehavior> behaviors, IEnumerable<IProvideNaming> namings)
        {
            if (behaviors == null)
                throw new ArgumentNullException("behaviors");
            if (namings == null)
                throw new ArgumentNullException("namings");

            _behaviors = behaviors.Concat(new[] { ConfiguredBehavior, AllFeatures.Disabled }).Where(x => x != null).ToList();
            _namings = namings.Concat(new[] { ConfiguredNaming, ProvideNaming.ByTypeFullName }).Where(x1 => x1 != null).ToList();
        }

        private string GetName<TFeature>()
            where TFeature : IFeature
        {
            return _namings.Select(x => x.For<TFeature>()).First(x1 => x1 != null);
        }

        public bool IsEnabled<TFeature>()
            where TFeature : IFeature
        {
            var feature = GetName<TFeature>();
            return _behaviors.Select(x => x.IsEnabled(feature)).First(x => x.HasValue).GetValueOrDefault();
        }
    }
}