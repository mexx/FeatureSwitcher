using FeatureSwitcher.Configuration;

namespace FeatureSwitcher.Examples
{
    class ConsoleColors : IShowExample, IFeature
    {
        public string Name { get { return "Switch console colors"; } }
        
        public void Show()
        {
            Features.Are.ConfiguredBy.Custom(Features.OfType<ConsoleColors>.Enabled);
        }
    }
}