namespace FeatureSwitcher.Behaviors.Internal
{
    class AllFeatures : IControlFeatures
    {
        private readonly bool _enabled;

        internal AllFeatures(bool enabled)
        {
            _enabled = enabled;
        }

        public bool IsEnabled(string feature)
        {
            return _enabled;
        }
    }
}