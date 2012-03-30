using System;

namespace FeatureSwitcher.Behaviors.Internal
{
    class AllFeatures : IControlFeatures
    {
        private readonly bool _enabled;

        internal AllFeatures(bool enabled)
        {
            _enabled = enabled;
        }

        public bool IsEnabled(Type feature)
        {
            return _enabled;
        }
    }
}