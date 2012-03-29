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

If you've got NuGet installed on your machine it gets even easier. Currently there are 2 packages available on NuGet. These are the framework and the [Bootstraper](http://bootstrapper.codeplex.com/) extension. If you want to use FeatureSwitcher just go ahead and type

    install-package FeatureSwitcher

into the package management console.

## How to use it

Create a class that name your feature and implement the IFeature interface.

	public class Sample : IFeature {}
	
In the code where you need the switch simply ask FeatureSwitcher if this feature is enabled.

	Feature<Sample>.IsEnabled
	
By default if no control feature behaviour is provided all features are disabled. To provided an behaviour simply assign it to ControlFeatures.Behaviour.

	ControlFeatures.Behaviour = new AllFeaturesEnabledBehaviour();