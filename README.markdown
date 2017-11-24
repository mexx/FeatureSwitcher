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

### Third party plugins
 
 * [FeatureSwitcher.DebugConsole](https://github.com/queueit/FeatureSwitcher.DebugConsole)<br/>
    A debug console for web applications that allows you to easily turn on and off features in MVC applications.
 * [FeatureSwitcher.AwsConfiguration](https://github.com/queueit/FeatureSwitcher.AwsConfiguration)<br/>
    Configuration plugin based on AWS services.
 * [FeatureSwitcher.Windsor](https://github.com/queueit/FeatureSwitcher.Windsor)<br/>
    Castle Windsor IoC plugin.
 * [FeatureSwitcher.Script](https://github.com/xunilrj/FeatureSwitcher.Script)<br/>
    Configure FeatureSwitcher features using scripts (javascript using jint).
 * [FeatureSwitcher.VstsConfiguration](https://github.com/AlegriGroup/FeatureSwitcher.VstsConfiguration)<br/>
    Configure FeatureSwitcher features using WorkItems in VSTS.

### Examples

Some [examples](https://github.com/mexx/FeatureSwitcher.Examples) of possible usage.

Please as well have a look on the [demo](https://github.com/emardini/FeatureSwitcherDemo) project by [emardini](https://github.com/emardini).

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

## Some arguments for feature toggles

* [Experience Report: Feature Toggling - Sarah Taraporewalla's Technical Ramblings](http://sarahtaraporewalla.com/design/experience-report-feature-toggling/)
* [Jay Fields' Thoughts: Experience Report: Feature Toggle over Feature Branch](http://blog.jayfields.com/2010/10/experience-report-feature-toggle-over.html)
* [Feature Toggle](http://martinfowler.com/bliki/FeatureToggle.html)
* [Process Automation and Continuous Delivery at OTTO.de](http://dev.otto.de/2015/11/24/process-automation-and-continuous-delivery-at-otto-de/)

## Alternatives?

* [nToggle](https://github.com/SteveMoyer/nToggle) found in 06/12
* [FeatureToggle](https://github.com/jason-roberts/FeatureToggle) found in 06/12
* [NFeature](https://github.com/benaston/NFeature) found in 06/12
* [Toggler](https://github.com/manojlds/Toggler) found at 12/12/12
* [Flipper](https://msarchet.github.com/Flipper) found at 01/01/13
* [Switcheroo](https://github.com/rhanekom/Switcheroo) found at 01/13/13
* [FlipIt](https://github.com/timscott/flipit) found at 01/13/13
* [c24.FeatureSwitcher](https://github.com/CHECK24/c24.FeatureSwitcher) found at 12/07/13
* [OnOff](https://github.com/larsw/OnOff) found at 01/12/14
* [FeatureToggler](https://github.com/hamidshahid/FeatureToggler) found at 08/12/14
* [Moon.Features](http://git.mooncode.net/moon.features) found at 09/14/14
* [FeatureSwitch](https://github.com/valdisiljuconoks/FeatureSwitch) found at 09/14/14
* [FeatureFlipper](https://github.com/ycrumeyrolle/FeatureFlipper) found at 09/14/14
* [ReallySimpleFeatureToggle](https://github.com/davidwhitney/ReallySimpleFeatureToggle) found at 09/14/14
* [FeatureBee](https://github.com/autoscout24/featurebee) found at 09/14/14
* [Togglr](https://github.com/jensandresen/togglr) found at 09/14/14
* [toggler.net](https://github.com/garfieldmoore/Feature-Toggle) found at 09/14/14
* [Ensign](https://github.com/sddaniels/Ensign) found at 09/14/14
* [Fooidity](https://github.com/phatboyg/Fooidity) found at 11/06/14
* [DevCookie](https://github.com/cottsak/DevCookie) found at 7/1/16
* [Collector.Common.FeatureFlags](https://github.com/collector-bank/common-featureflags) found at 11/24/17
* [LaazyFeatureToggle](https://github.com/laazyj/LaazyFeatureToggle) found at 11/24/17
* [FeatureFlags.Abstractions](https://github.com/sragu/FeatureFlags.Abstractions.git) found at 11/24/17

## Why this library?

Before this library was born, the existed alternatives (nToggle, FeatureToggle and NFeature) was tested.

The API of the first two is toggle centric it meens you have to decide while you coding how a feature is later controlled in production ex. using date range or database entry. Although the API of the last one is feature centric a feature must be defined as enum value what makes it complex for configuration.

A new library with a better feature centric API is needed, the FeatureSwitcher is born.

### Background infos about API design

Why is a feature not<br/>
* a `string` like by nToggle<br/>
   This is really simple -> MagicString
* an `enum` value like by NFeature<br/>
   All features are defined in one place. At the first look it is cool, you can find all features easily, but you can't easily modularize the code ex. provide new features as addins.
* a `class` like by FeatureToggle<br/>
   Actually there is no notion of a feature only of a toggle in FeatureToggle. A concrete feature toggle is defined by inheritance of a particular base type what defines how the feature is controlled in the future. The flexibility of this decision is lost. In addition the requirement of inheritance prevents the application in existing class hierarchies.

Decision: A feature must implement a marker interface! `IFeature`<br/>
Actually, the API could get along without this marker interface, the only reason for the interface is that you can, if it will be necessary, identify all the features by reflection or IDE.

Decision: A static generic class! `Feature<>`<br/>
Somehow you have to get from the feature to the state of the switch controlling it. Syntactic sugar.

## Mentions

* [David Gardiner - Dave's Daydreams: Feature Toggle libraries for .NET](http://david.gardiner.net.au/2012/07/feature-toggle-libraries-for-net.html)
* [Phil Hale - Stuff that interests me: A brief look at some feature toggle tools](http://www.philjhale.com/2012/07/a-brief-look-at-some-feature-toggle.html)
* [Patrice Lamarche - Gestion des évolutions grâce aux Feature Flags](http://patricelamarche.net/2013/03/11/gestion-des-volutions-grce-aux-feature-flags)
* [Jan Vandenbussche: Feature Toggle libraries for .NET](http://blog.janvandenbussche.be/2013/10/feature-toggle-libraries-for-net.html)
* [Slides](https://slid.es/mexx/featureswitcher) from short talk at [ALT.NET Berlin UG](http://www.altnetberlin.de)
* [Ob du Rechte hast oder nicht ...](http://www.dotnetpro.de/A1501Frameworks) article from [dotnetpro](http://www.dotnetpro.de/) magazine in German
* [Simple Feature Toggles For Xamarin Apps (And Everything Else)](https://thomasbandt.com/simple-feature-toggles-for-xamarin-apps-and-everything-else)
