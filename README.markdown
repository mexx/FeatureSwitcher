# What is FeatureSwitcher?

FeatureSwitcher is little library build to support you when you want to introduce feature switches/toggles in your code.

If needed it provides multi tenancy support. [more info](#multi-tenancy--context-support)

## How to use it

Create a class that names your feature and mark it with the `IFeature` interface.

	class Sample : IFeature {}

Ask whether `Feature<Sample>.Is().Enabled` or `Feature<Sample>.Is().Disabled`.

With an instance of your feature 

	var sample = new Sample();

Ask whether `sample.Is().Enabled` or `sample.Is().Disabled`.

The state of the feature is determined by applying the behavior function to the feature name retrived by applying the naming convention function to the type of the feature.

### Behavior and naming convention

Provided naming conventions

* `Features.OfAnyType.NamedByTypeFullName`
* `Features.OfAnyType.NamedByTypeName`
* `Features.OfType<T>.NamedByTypeFullName`
* `Features.OfType<T>.NamedByTypeName`

You can define an own naming convention with a function assignable to the `Feature.NamingConvention` delegate.

Provided behaviors

* `Features.OfAnyType.Enabled`
* `Features.OfAnyType.Disabled`
* `Features.OfType<T>.Enabled`
* `Features.OfType<T>.Disabled`
* `AppConfig.IsEnabled` (via [FeatureSwitcher.Configuration](https://github.com/mexx/FeatureSwitcher.Configuration) plugin)

You can define an own behavior with a function assignable to the `Feature.Behavior` delegate.

### Configuration

By default all features are disabled and named by fullname of the type.
You can provide an own behavior or naming convention simply by pass it into the configuration.

	Features.Are
		.ConfiguredBy.Custom(behavior).And
		.NamedBy.Custom(namingConvention);

### Multi tenancy / context support

Sometimes e.g. in a multitenant application you have features which should be enabled or disabled dependant of a context e.g. tenant. The plugin [FeatureSwitcher.Contexteer](https://github.com/mexx/FeatureSwitcher.Contexteer) provides support for contexts by utilizing [Contexteer](https://github.com/mexx/Contexteer).

Assuming you have a context class named `BusinessBranch` and an instance of it named `businessBranch` you can ask FeatureSwitcher if your feature is enabled or disabled

	Feature<Sample>.Is().EnabledInContextOf(businessBranch)
	Feature<Sample>.Is().DisabledInContextOf(businessBranch)

And for an instance of your feature

	sample.Is().EnabledInContextOf(businessBranch)
	sample.Is().DisabledInContextOf(businessBranch)

You can provide own behavior and naming convention for contexts also by passing it into the configuration.

	In<BusinessBranch>.Contexts.FeaturesAre()
		.ConfiguredBy(behavior).And
		.NamedBy(namingConvention);

### Examples

Some [examples](https://github.com/mexx/FeatureSwitcher.Examples) of possible usage.

## How to get it

### NuGet package manager

There are three packages
 
* FeatureSwitcher - needed to do all the magic
* FeatureSwitcher.Configuration - needed to configure the magic by app.config
* FeatureSwitcher.Contexteer - needed to add context magic

## How to contribute code

* Login in github (you need an account)
* Fork the main repository from [Github](https://github.com/mexx/FeatureSwitcher)
* Push your changes to your GitHub repository
* Send a pull request

## Versioning

Versioning follows the [Semantic Versioning Specification](http://semver.org/).