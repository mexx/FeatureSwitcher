using FeatureSwitcher.Configuration;

namespace FeatureSwitcher.Examples
{
    class EnableAll : IShowExample
    {
        public string Name { get { return "Enable all features"; } }

        public void Show()
        {
            Features.Are.AlwaysEnabled();
        }
    }
}