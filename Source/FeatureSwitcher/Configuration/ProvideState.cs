using System;

namespace FeatureSwitcher.Configuration
{
    public sealed class ProvideState : IProvideState
    {
        private static IProvideBehavior _configuredBehavior;

        public static IProvideBehavior ConfiguredBehavior
        {
            get { return _configuredBehavior ?? AllFeatures.Disabled; }
            internal set { _configuredBehavior = value; }
        }

        private static IProvideNaming _configuredNaming;

        public static IProvideNaming ConfiguredNaming
        {
            get { return _configuredNaming ?? ProvideNaming.ByTypeFullName; }
            internal set { _configuredNaming = value; }
        }

        internal static ProvideState Control
        {
            get { return new ProvideState(ConfiguredBehavior, ConfiguredNaming); }
        }

        public ProvideState(IProvideBehavior behavior, IProvideNaming naming)
        {
            if (behavior == null)
                throw new ArgumentNullException("behavior");
            if (naming == null)
                throw new ArgumentNullException("naming");

            Behavior = behavior;
            Naming = naming;
        }

        public IProvideBehavior Behavior { get; private set; }
        public IProvideNaming Naming { get; private set; }

        public bool IsEnabled<TFeature>()
            where TFeature : IFeature
        {
            return Behavior.IsEnabled(Naming.For<TFeature>()).GetValueOrDefault();
        }
    }
}