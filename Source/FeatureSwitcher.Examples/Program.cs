using System;
using System.Diagnostics;
using FeatureSwitcher.Behaviors;

namespace FeatureSwitcher.Examples
{
    internal class Myth : IFeature {}

    internal class BlueBackground : IFeature {}

    class Program
    {
        static void Main(string[] args)
        {
            ControlFeatures.Behavior = new WithAppConfig(true);

            if (Feature<BlueBackground>.IsEnabled)
                Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine("Myth feature is {0}", Feature<Myth>.IsEnabled ? "enabled" : "disabled");
            if (Debugger.IsAttached)
                Console.ReadLine();
        }
    }
}
