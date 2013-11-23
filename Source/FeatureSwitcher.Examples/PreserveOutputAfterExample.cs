using FeatureSwitcher.Configuration;

namespace FeatureSwitcher.Examples
{
    class PreserveOutputAfterExample : IShowExample, IFeature
    {
        public string Name { get { return "Preserve output after example"; } }

        public void Show()
        {
            Features.Are.ConfiguredBy.Custom(Features.OfType<PreserveOutputAfterExample>.Enabled);
        }
    }
}