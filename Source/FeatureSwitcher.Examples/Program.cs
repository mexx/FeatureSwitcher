using System;
using System.Diagnostics;
using System.Linq;

namespace FeatureSwitcher.Examples
{
    internal class Myth : IFeature {}

    internal class BlueBackground : IFeature {}

    internal class Named: IFeature {}

    internal class BusinessBranch : IFeatureContext
    {
        public static readonly BusinessBranch HQ = new BusinessBranch();

        private BusinessBranch()
        {
        }
    }

    public static class F
    {
        public static FeatureSettings ControlFeatures(this IFeatureContext This)
        {
            throw new NotImplementedException();
        }

        public static FeatureWithContext<T> Feature<T>(this IFeatureContext This, T feature) where T:IFeature
        {
            return new FeatureWithContext<T>(This);
        }

        public static FeatureWithContext<T> Feature<T>(this IFeatureContext This) where T : IFeature
        {
            return new FeatureWithContext<T>(This);
        }
    }

    public class FeatureSettings
    {
        public IControlFeatures Behavior { get; set; }

        public IProvideFeatureNames Name { get; set; }
    }

    public class FeatureWithContext<T>
    {
        private readonly IFeatureContext _context;

        public FeatureWithContext(IFeatureContext context)
        {
            _context = context;
        }

        public bool IsEnabled
        {
            get { throw new NotImplementedException(); }
        }
    }

    public interface IFeatureContext
    {
    }

    public static class Default
    {
        public static IFeatureContext Context
        {
            get { return null; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BusinessBranch.HQ.ControlFeatures().Behavior = Use.SettingsFrom.AppConfig().IgnoreConfigurationErrors();
            BusinessBranch.HQ.ControlFeatures().Name = Use.Type.FullName;

            ControlFeatures.Behavior = Use.SettingsFrom.AppConfig().IgnoreConfigurationErrors();
            ControlFeatures.Name = Use.Type.FullName;

            if (Feature<BlueBackground>.IsEnabled)
                Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine("Myth feature is {0}", Feature<Myth>.IsEnabled ? "enabled" : "disabled");
            if (Debugger.IsAttached)
                Console.ReadLine();


            var branch = BusinessBranch.HQ;
            var named = new Named();

            var a = Feature<Named>.IsEnabled;
            var b = Default.Context.Feature<Named>().IsEnabled;
            var c = branch.Feature<Named>().IsEnabled;

            var d = named.IsEnabled();
            var e = Default.Context.Feature(named).IsEnabled;
            var f = branch.Feature(named).IsEnabled;

            var features = new IFeature[] {new Myth(), new BlueBackground()};
            foreach (var feature in features.
                Where(Feature.IsEnabled).
                Where(x => Default.Context.Feature(x).IsEnabled).
                Where(x => branch.Feature(x).IsEnabled))
            {
                feature.IsEnabled();
            }
        }
    }
}
