using System;
using System.Diagnostics;
using System.Linq;
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

            InContexts.OfType<BusinessBranch>().FeaturesAre().
                AlwaysDisabled();

            InContexts.OfType<BusinessBranch>().FeaturesAre().
                AlwaysEnabled().And.
                NamedBy.TypeFullName();

            InContexts.OfType<BusinessBranch>().FeaturesAre().
                NamedBy.TypeName();

            InContexts.OfType<BusinessBranch>().FeaturesAre().
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

            ByDefault.FeaturesAre.
                HandledByDefault();

            ByDefault.FeaturesAre.
                ConfiguredBy.AppConfig().IgnoreConfigurationErrors();

            if (Feature<BlueBackground>.IsEnabled)
                Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine("Myth feature is {0}", Feature<Myth>.IsEnabled ? "enabled" : "disabled");
            if (Debugger.IsAttached)
                Console.ReadLine();


            var branch = BusinessBranch.HQ;
            var named = new TestNamed();

            var a = Feature<TestNamed>.IsEnabled;
            var c = InContext.Of(branch).Feature<TestNamed>().IsEnabled;

            var d = named.IsEnabled();
            var f = InContext.Of(branch).Feature(named).IsEnabled;

            var features = new IFeature[] {new Myth(), new BlueBackground()};
            foreach (var feature in features.
                Where(Feature.IsEnabled).
                Where(InContext.Of(branch).FeatureIsEnabled))
            {
                feature.IsEnabled();
            }

            foreach (var feature in features.
                Select(InContext.Of(branch).Feature))
            {
                var b = feature.IsEnabled;
            }
        }
    }
}
