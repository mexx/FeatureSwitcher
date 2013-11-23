using System;
using System.Diagnostics;
using System.Linq;
using Contexteer;
using Contexteer.Configuration;
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
            Examples.Show();

            Features.Are.
                AlwaysEnabled();
            In<BusinessBranch>.Contexts.FeaturesAre().
                AlwaysEnabled();
            In<BusinessBranch>.Contexts.FeaturesAre().
                AlwaysEnabled();

            Features.Are.
                AlwaysEnabled();

            Features.Are.
                AlwaysDisabled().And.
                NamedBy.TypeName();

            Features.Are.
                NamedBy.TypeFullName();

            Features.Are.
                NamedBy.TypeFullName().And.
                AlwaysEnabled();

            In<BusinessBranch>.Contexts.FeaturesAre().
                AlwaysDisabled();

            In<BusinessBranch>.Contexts.FeaturesAre().
                AlwaysEnabled().And.
                NamedBy.TypeFullName();

            In<BusinessBranch>.Contexts.FeaturesAre().
                NamedBy.TypeName();

            In<BusinessBranch>.Contexts.FeaturesAre().
                NamedBy.TypeName().And.
                AlwaysEnabled();

            Features.Are.
                ConfiguredBy.AppConfig().And.
                NamedBy.TypeName();

            Features.Are.
                ConfiguredBy.AppConfig().UsingConfigSectionGroup("featureSwitcher.hq").And.
                NamedBy.TypeName();

            Features.Are.
                ConfiguredBy.AppConfig().IgnoreConfigurationErrors().And.
                NamedBy.TypeName();

            Features.Are.
                ConfiguredBy.AppConfig().UsingConfigSectionGroup("featureSwitcher.hq").IgnoreConfigurationErrors().And.
                NamedBy.TypeName();

            Features.Are.
                ConfiguredBy.AppConfig().IgnoreConfigurationErrors().UsingConfigSectionGroup("featureSwitcher.hq").And.
                NamedBy.TypeName();

            Features.Are.
                ConfiguredBy.AppConfig().UsingConfigSectionGroup("featureSwitcher.hq");

            Features.Are.
                NamedBy.TypeFullName();

            Features.Are.
                NamedBy.TypeFullName().And.
                ConfiguredBy.AppConfig().UsingConfigSectionGroup("featureSwitcher.hq");

            Features.Are.
                HandledByDefault();

            Features.Are.
                ConfiguredBy.AppConfig().IgnoreConfigurationErrors();

            if (Feature<BlueBackground>.Is().Enabled)
                Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine("Myth feature is {0}", Feature<Myth>.Is().Enabled ? "enabled" : "disabled");
            if (Debugger.IsAttached)
                Console.ReadLine();


            var branch = BusinessBranch.HQ;
            var named = new TestNamed();

            var a = Feature<TestNamed>.Is().Enabled;
            var c = Feature<TestNamed>.Is().EnabledInContextOf(branch);

            var d = named.Is().Enabled;
            var f = named.Is().EnabledInContextOf(branch);

            var features = new IFeature[] {new Myth(), new BlueBackground()};
            foreach (var feature in features.
                Where(x => x.Is().Enabled).
                Where(x => x.Is().EnabledInContextOf(branch)))
            {
                var b = feature.Is().Enabled;
            }
            foreach (var feature in features.Select(Feature.Is).
                Where(x => x.Enabled).
                Where(x => x.EnabledInContextOf(branch)))
            {
                var b = feature.Enabled;
            }
        }
    }
}
