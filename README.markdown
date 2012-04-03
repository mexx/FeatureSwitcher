# What is FeatureSwitcher ?

FeatureSwitcher is little framework build to support you when you want to introduce feature switches/toggles in your code.

## How to contribute code

* Login in github (you need an account)
* Fork the main repository from [Github](https://github.com/mexx/FeatureSwitcher)
* Please contribute only on the dev branch. (There is no development on the master branch. Only the releases are build from there)
* Push your changes to your GitHub repository.
* Send us a pull request

# How to get started

## Building FeatureSwitcher from source

Just download the repository from github and run the build.cmd (or build.NoGit.cmd if you don't have git installed). The build of FeatureSwitcher only requires the .NET Framework 4.0 to be installed on your machine. Everything else should work out-of-the-box. If not, please take the time to add an issue to this project. After a succesful build you find all the assemblies in a zip file under the "Release" folder.

## Getting FeatureSwitcher via the NuGet package manager

If you've got NuGet installed on your machine it gets even easier. Currently there are two packages available on NuGet. These are the framework and the configuration behavior. If you want to use FeatureSwitcher just go ahead and type

    install-package FeatureSwitcher

or for configuration behavior type

    install-package FeatureSwitcher.Configuration
	
into the package management console.

It is planned to provide a [Bootstraper](http://bootstrapper.codeplex.com/) extension as NuGet package.

## How to use it

Create a class that name your feature and implement the IFeature interface.

	public class Sample : IFeature {}
	
In the code where you need the switch simply ask FeatureSwitcher if this feature is enabled or disabled

	Feature<Sample>.IsEnabled
	Feature<Sample>.IsDisabled

If your have an instance of your feature and want to check it is enabled or disabled

	instance.IsEnabled()
	instance.IsDisabled()

You can even filter a list of features very simple

	list.Where(Feature.IsEnabled)
	list.Where(Feature.IsDisabled)
	
By default if no control feature behavior is provided all features are disabled. To provide a behavior simply assign it to ControlFeatures.Behavior.

	ControlFeatures.Behavior = Use.AllFeatures.Enabled;

By default if no naming strategy is provided fullname of the type is used. To provide an own strategy simply assign it to ControlFeatures.Name.

	ControlFeatures.Name = Use.Type.Name;

# Versioning

For version numbers we follow the [Semantic Versioning Specification](http://semver.org/).
