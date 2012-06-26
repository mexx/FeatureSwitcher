using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureSwitcher.Configuration
{
    public sealed class ProvideState : IProvideState
    {
        internal static IProvideBehavior[] ConfiguredBehaviors { get; set; }
        internal static IProvideNaming[] ConfiguredNamings { get; set; }

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

            _behaviors = behaviors.Concat(ConfiguredBehaviors ?? new IProvideBehavior[0]).Concat(new[] { AllFeatures.Disabled }).Where(x => x != null).ToList();
            _namings = namings.Concat(ConfiguredNamings ?? new IProvideNaming[0]).Concat(new[] { ProvideNaming.ByTypeFullName }).Where(x => x != null).ToList();
        }

        private string GetName<TFeature>()
            where TFeature : IFeature
        {
            return _namings.Select(x => x.For<TFeature>()).First(x => x != null);
        }

        public bool IsEnabled<TFeature>()
            where TFeature : IFeature
        {
            var feature = GetName<TFeature>();
            return _behaviors.Select(x => x.IsEnabled(feature)).First(x => x.HasValue).GetValueOrDefault();
        }
    }
}