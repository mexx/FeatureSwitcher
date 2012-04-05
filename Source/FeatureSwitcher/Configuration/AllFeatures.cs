namespace FeatureSwitcher.Configuration
{
    public sealed class AllFeatures : IControlFeatures
    {
        public static readonly IControlFeatures Enabled = new AllFeatures(true);
        public static readonly IControlFeatures Disabled = new AllFeatures(false);

        private readonly bool _enabled;

        private AllFeatures(bool enabled)
        {
            _enabled = enabled;
        }

        public bool IsEnabled(string feature)
        {
            return _enabled;
        }
    }
}