namespace FeatureSwitcher.Configuration
{
    public sealed class AllFeatures : IProvideBehavior
    {
        public static readonly IProvideBehavior Enabled = new AllFeatures(true);
        public static readonly IProvideBehavior Disabled = new AllFeatures(false);

        private readonly bool _enabled;

        private AllFeatures(bool enabled)
        {
            _enabled = enabled;
        }

        bool IProvideBehavior.IsEnabled(string feature)
        {
            return _enabled;
        }
    }
}