namespace FeatureSwitcher.Configuration
{
    public sealed class AllFeatures : IProvideBehavior
    {
        public static IProvideBehavior Enabled { get; private set; }
        public static IProvideBehavior Disabled { get; private set; }

        static AllFeatures()
        {
            Enabled = new AllFeatures(true);
            Disabled = new AllFeatures(false);
        }

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