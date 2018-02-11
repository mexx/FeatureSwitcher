using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
    public class When_all_features_are_enabled : WithCleanUp
    {
        Because of = () => Features.Are.AlwaysEnabled();

        class when_using_basic
        {
            Behaves_like<Enabled<Basic>> an_enabled_basic_feature;
        }

        class when_using_simple
        {
            Behaves_like<Enabled<Simple>> an_enabled_simple_feature;
        }
        
        class when_using_complex
        {
            Behaves_like<Enabled<Complex>> an_enabled_complex_feature;
        }
    }
}