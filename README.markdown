# What is FeatureSwitcher ?

FeatureSwitcher is little library build to support you when you want to introduce feature switches/toggles in your code.

If needed it provides multi tenancy support. [more info](#multi-tenancy--context-support)

## How to use it

Create a class that names your feature and mark it with the `IFeature` interface.

	class Sample : IFeature {}

Ask whether `Feature<Sample>.Is().Enabled` or `Feature<Sample>.Is().Disabled`.

With an instance of your feature 
	
	var sample = new Sample();

Ask whether `sample.Is().Enabled` or `sample.Is().Disabled`.

### Configuration

By default all features are disabled and named by fullname of the type.
You can provide an own behavior or naming strategy simply by pass it into the configuration.

	Features.Are
		.ConfiguredBy.Custom(behavior).And
		.NamedBy.Custom(namingConvention);

### Multi tenancy / context support

Sometimes e.g. in a multitenant application you have features which should be enabled or disabled dependant of a context e.g. tenant. FeatureSwitcher provides support for contexts by utilizing [Contexteer](https://github.com/mexx/Contexteer).

Assuming you have a context class named `BusinessBranch` and an instance of it named `businessBranch` you can ask FeatureSwitcher if your feature is enabled or disabled

	Feature<Sample>.Is().EnabledInContextOf(businessBranch)
	Feature<Sample>.Is().DisabledInContextOf(businessBranch)

And for an instance of your feature

	sample.Is().EnabledInContextOf(businessBranch)
	sample.Is().DisabledInContextOf(businessBranch)

You can provide own behavior and naming strategy for contexts also by passing it into the configuration.

	In<BusinessBranch>.Contexts.FeaturesAre()
		.ConfiguredBy(behavior).And
		.NamedBy(naming);

## How to get it

### NuGet package manager

There are three packages
 
* FeatureSwitcher - needed to do all the magic
* FeatureSwitcher.Configuration - needed to configure the magic
* FeatureSwitcher.Contexteer - needed to add context magic

### Build from source

Just download the repository from github and run the build.cmd (or build.NoGit.cmd if you don't have git installed). The build of FeatureSwitcher only requires the .NET Framework 4.0 to be installed on your machine. Everything else should work out-of-the-box. If not, please take the time to add an issue to this project. After a succesful build you find all the assemblies in a zip file under the "Release" folder.

## How to contribute code

* Login in github (you need an account)
* Fork the main repository from [Github](https://github.com/mexx/FeatureSwitcher)
* Please contribute only on the dev branch. (There is no development on the master branch. Only the releases are build from there)
* Push your changes to your GitHub repository.
* Send us a pull request

## Versioning

Versioning follows the [Semantic Versioning Specification](http://semver.org/).