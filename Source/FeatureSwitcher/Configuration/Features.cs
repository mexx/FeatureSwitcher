namespace FeatureSwitcher.Configuration
{
    public static class Features
    {
        private static readonly ConfigureFeatures ConfigureFeatures = new ConfigureFeatures();

        public static IConfigureFeatures Are
        {
            get { return ConfigureFeatures; }
        }
    }
}