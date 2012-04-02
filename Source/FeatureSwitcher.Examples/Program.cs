using System;
using System.Diagnostics;
using System.Linq;

namespace FeatureSwitcher.Examples
{
    internal class Myth : IFeature {}

    internal class BlueBackground : IFeature {}

    internal class Named: IFeature {}

    class Program
    {
        static void Main(string[] args)
        {
            ControlFeatures.Behavior = Use.SettingsFrom.AppConfig().IgnoreConfigurationErrors();
            ControlFeatures.Name = Use.Type.FullName;

            if (Feature<BlueBackground>.IsEnabled)
                Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine("Myth feature is {0}", Feature<Myth>.IsEnabled ? "enabled" : "disabled");
            if (Debugger.IsAttached)
                Console.ReadLine();

            var named = new Named();
            var enabled = named.IsEnabled();
            var isEnabled = Feature<Named>.IsEnabled;

            var features = new IFeature[] {new Myth(), new BlueBackground()};
            foreach (var feature in features.Where(Feature.IsEnabled))
            {
                feature.IsEnabled();
            }
        }
    }
}
