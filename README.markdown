# What is FeatureSwitcher ?

FeatureSwitcher is little framework build to support you when you want to introduce feature switches/toggles in your code.

If needed it provides multi tenancy support. [more info](#Multi-tenancy--context-support)

## How to use it

Create a class that names your feature and implements the IFeature interface.

	class Sample : IFeature {}

In the code where you need the switch simply ask FeatureSwitcher if your feature is enabled or disabled

	Feature<Sample>.Is().Enabled
	Feature<Sample>.Is().Disabled

If your have an instance of your feature and want to check it is enabled or disabled

	var sample = new Sample();
	sample.Is().Enabled
	sample.Is().Disabled

By default all features are disabled. You can provide an own behavior simply by pass it into the configuration.

	Features.Are.ConfiguredBy.Custom(new MyBehavior());

By default fullname of the type is used to name a feature. To provide an own naming strategy simply pass it into the configuration.

	Features.Are.NamedBy.Custom(new MyNaming());

### Multi tenancy / context support

Sometimes e.g. in a multitenant application you have features which should be enabled or disabled dependant of a context e.g. tenant. FeatureSwitcher provides support for contexts by utilizing [Contexteer](https://github.com/mexx/Contexteer).

Assuming you have a context class named `BusinessBranch` and an instance of it named `businessBranch` you can ask FeatureSwitcher if your feature is enabled or disabled

	Feature<Sample>.Is().EnabledInContextOf(businessBranch)
	Feature<Sample>.Is().DisabledInContextOf(businessBranch)

And for an instance of your feature

	sample.Is().EnabledInContextOf(businessBranch)
	sample.Is().DisabledInContextOf(businessBranch)

You can provide own behavior and naming strategy for contexts also by passing it into the configuration.

	In<BusinessBranch>.Contexts.FeaturesAre().ConfiguredBy(ctx => new MyBehavior(ctx));

	In<BusinessBranch>.Contexts.FeaturesAre().NamedBy(ctx => new MyNaming(ctx));

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