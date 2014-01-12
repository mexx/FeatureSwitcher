using FeatureSwitcher.Configuration;
using FeatureSwitcher.Specs.Behaviors;
using FeatureSwitcher.Specs.Contexts;
using FeatureSwitcher.Specs.Domain;
using Machine.Specifications;

namespace FeatureSwitcher.Specs
{
	public class When_using_in_memory_behavior : WithCleanUp
	{
		Establish ctx = () => {
			InMemory inMemory = new InMemory();
			inMemory.Disable<Basic>();
			inMemory.Enable<Simple>();
			inMemory.Enable<Complex>();
			inMemory.Reset<Complex>();
			Features.Are.ConfiguredBy.Custom(inMemory.IsEnabled);
		};

		Behaves_like<Disabled<Basic>> a_disabled_basic_feature;

		Behaves_like<Enabled<Simple>> an_enabled_simple_feature;

		Behaves_like<Disabled<Complex>> a_disabled_complex_feature;
	}
}