using System;
using System.Diagnostics;
using System.Linq;
using ContextSwitcher;
using FeatureSwitcher.Configuration;

namespace FeatureSwitcher.Examples
{
    internal class Myth : IFeature {}

    internal class BlueBackground : IFeature {}

    internal class TestNamed: IFeature {}

    internal class BusinessBranch : IContext
    {
        public static readonly BusinessBranch HQ = new BusinessBranch();

        private BusinessBranch()
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            ByDefault.FeaturesAre.
                AlwaysEnabled();

            ByDefault.FeaturesAre.
                AlwaysDisabled().And.
                NamedBy.TypeName();

            ByDefault.FeaturesAre.
                NamedBy.TypeFullName();

            ByDefault.FeaturesAre.
                NamedBy.TypeFullName().And.
                AlwaysEnabled();

            InContexts.OfType<BusinessBranch>().FeaturesAre.ConfiguredBy.Test();

            Use.Context[BusinessBranch.HQ].WithFeatures.
                AlwaysDisabled();

            Use.Context[BusinessBranch.HQ].WithFeatures.
                AlwaysEnabled().And.
                NamedBy.TypeFullName();

            Use.Context[BusinessBranch.HQ].WithFeatures.
                NamedBy.TypeName();

            Use.Context[BusinessBranch.HQ].WithFeatures.
                NamedBy.TypeName().And.
                AlwaysEnabled();


            ByDefault.FeaturesAre.
                ConfiguredBy.AppConfig().And.
                NamedBy.TypeName();

            ByDefault.FeaturesAre.
                ConfiguredBy.AppConfig().UsingConfigSectionGroup("featureSwitcher.hq").And.
                NamedBy.TypeName();

            ByDefault.FeaturesAre.
                ConfiguredBy.AppConfig().IgnoreConfigurationErrors().And.
                NamedBy.TypeName();

            ByDefault.FeaturesAre.
                ConfiguredBy.AppConfig().UsingConfigSectionGroup("featureSwitcher.hq").IgnoreConfigurationErrors().And.
                NamedBy.TypeName();

            ByDefault.FeaturesAre.
                ConfiguredBy.AppConfig().IgnoreConfigurationErrors().UsingConfigSectionGroup("featureSwitcher.hq").And.
                NamedBy.TypeName();

            ByDefault.FeaturesAre.
                ConfiguredBy.AppConfig().UsingConfigSectionGroup("featureSwitcher.hq");

            ByDefault.FeaturesAre.
                NamedBy.TypeFullName();

            ByDefault.FeaturesAre.
                NamedBy.TypeFullName().And.
                ConfiguredBy.AppConfig().UsingConfigSectionGroup("featureSwitcher.hq");

            if (Feature<BlueBackground>.IsEnabled)
                Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine("Myth feature is {0}", Feature<Myth>.IsEnabled ? "enabled" : "disabled");
            if (Debugger.IsAttached)
                Console.ReadLine();


            var branch = BusinessBranch.HQ;
            var named = new TestNamed();

            var a = Feature<TestNamed>.IsEnabled;
//            var b = Context.Default.Feature<TestNamed>().IsEnabled;
            var c = InContext.Of(branch).Feature<TestNamed>().IsEnabled;

            var d = named.IsEnabled();
//            var e = Context.Default.Feature(named).IsEnabled;
            var f = InContext.Of(branch).Feature(named).IsEnabled;

            var features = new IFeature[] {new Myth(), new BlueBackground()};
            foreach (var feature in features.
                Where(Feature.IsEnabled).
//                Where(x => Default.Context.Feature(x).IsEnabled).
                Where(x => InContext.Of(branch).Feature(x).IsEnabled))
            {
                feature.IsEnabled();
            }
        }
    }
}
