using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher.Configuration
{
    public static class InContexts
    {
        public static ConfigurationFor<TContext> OfType<TContext>() where TContext : IContext
        {
            return new ConfigurationFor<TContext>();
        }
    }

    public sealed class ConfigurationFor<TContext> where TContext : IContext
    {
        internal ConfigurationFor() {}

        public IConfigureFeaturesFor<TContext> FeaturesAre
        {
            get { return new FeatureConfigurationFor<TContext>(); }
        }
    }

    public static class Default
    {
        public static void HandledByDefault<TContext>(this IConfigureFeaturesFor<TContext> This) where TContext : IContext
        {
            This.ConfiguredBy.Custom((IInContextOf<TContext, IControlFeatures>)null);
            This.NamedBy.Custom((IInContextOf<TContext, IProvideNaming>)null);
        }
    }

    public static class Always
    {
        public static IConfigureFeaturesFor<TContext> AlwaysEnabled<TContext>(this IConfigureFeaturesFor<TContext> This) where TContext : IContext
        {
            return This.ConfiguredBy.Custom(AllFeatures.Enabled);
        }

        public static IConfigureFeaturesFor<TContext> AlwaysDisabled<TContext>(this IConfigureFeaturesFor<TContext> This) where TContext : IContext
        {
            return This.ConfiguredBy.Custom(AllFeatures.Disabled);
        }
    }

    internal class FeatureConfigurationFor<TContext> : IConfigureFeaturesFor<TContext> where TContext : IContext
    {
        public IConfigureFeaturesFor<TContext> And
        {
            get { return this; }
        }

        public IConfigureNamingIn<TContext> NamedBy
        {
            get { return new ConfigureNamingIn<TContext>(this); }
        }

        public IConfigureBehaviorIn<TContext> ConfiguredBy
        {
            get { return new ConfigureBehaviorIn<TContext>(this); }
        }
    }

    internal class ConfigureBehaviorIn<TContext> : IConfigureBehaviorIn<TContext> where TContext : IContext
    {
        private readonly FeatureConfigurationFor<TContext> _featureConfigurationFor;

        public ConfigureBehaviorIn(FeatureConfigurationFor<TContext> featureConfigurationFor)
        {
            _featureConfigurationFor = featureConfigurationFor;
        }

        public IConfigureFeaturesFor<TContext> Custom(IInContextOf<TContext, IControlFeatures> value)
        {
            Control.ConfigFor<TContext>().Set(value);
            return _featureConfigurationFor;
        }

        public IConfigureFeaturesFor<TContext> Custom(IControlFeatures value)
        {
            return Custom(NoContext<TContext>.SupportFor(value));
        }
    }

    internal class ConfigureNamingIn<TContext> : IConfigureNamingIn<TContext> where TContext : IContext
    {
        private readonly FeatureConfigurationFor<TContext> _featureConfigurationFor;

        public ConfigureNamingIn(FeatureConfigurationFor<TContext> featureConfigurationFor)
        {
            _featureConfigurationFor = featureConfigurationFor;
        }

        public IConfigureFeaturesFor<TContext> Custom(IInContextOf<TContext, IProvideNaming> value)
        {
            Control.ConfigFor<TContext>().Set(value);
            return _featureConfigurationFor;
        }

        public IConfigureFeaturesFor<TContext> Custom(IProvideNaming value)
        {
            return Custom(NoContext<TContext>.SupportFor(value));
        }
    }
}