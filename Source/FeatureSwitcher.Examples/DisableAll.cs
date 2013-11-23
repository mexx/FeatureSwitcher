using FeatureSwitcher.Configuration;

namespace FeatureSwitcher.Examples
{
    class DisableAll : IShowExample
    {
        public string Name { get { return "Disable all features"; } }

        public void Show()
        {
            Features.Are.AlwaysDisabled();
        }
    }
}