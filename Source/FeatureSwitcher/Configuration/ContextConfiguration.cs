using System;
using ContextSwitcher;
using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher.Configuration
{
    public static class InContexts
    {
        public static ContextConfiguration<T> OfType<T>() where T : IContext
        {
            return new ContextConfiguration<T>();
        }
    }

    public sealed class ContextConfiguration<TContext> where TContext : IContext
    {
        internal ContextConfiguration() {}

        public IFeatureConfiguration<TContext> FeaturesAre
        {
            get { return new FeatureConfigurationFor<TContext>(); }
        }
    }

    public static class Default
    {
        public static void HandledByDefault<TContext>(this IFeatureConfiguration<TContext> This) where TContext : IContext
        {
            This.ConfiguredBy.Custom((ISupportContextFor<IControlFeatures, TContext>) null);
            This.NamedBy.Custom((ISupportContextFor<IProvideNaming, TContext>) null);
        }
    }

    public static class Always
    {
        public static IFeatureConfiguration<TContext> AlwaysEnabled<TContext>(this IFeatureConfiguration<TContext> This) where TContext : IContext
        {
            return This.ConfiguredBy.Custom(AllFeatures.Enabled);
        }

        public static IFeatureConfiguration<TContext> AlwaysDisabled<TContext>(this IFeatureConfiguration<TContext> This) where TContext : IContext
        {
            return This.ConfiguredBy.Custom(AllFeatures.Disabled);
        }
    }

    internal class FeatureConfigurationFor<TContext> : IFeatureConfiguration<TContext> where TContext : IContext
    {
        public IFeatureConfiguration<TContext> And
        {
            get { return this; }
        }

        public IConfigureNaming<TContext> NamedBy
        {
            get { return new ConfigureNaming<TContext>(this); }
        }

        public IConfigureBehavior<TContext> ConfiguredBy
        {
            get { return new ConfigureBehavior<TContext>(this); }
        }
    }

    internal class ConfigureBehavior<TContext> : IConfigureBehavior<TContext> where TContext : IContext
    {
        private readonly FeatureConfigurationFor<TContext> _featureConfigurationFor;

        public ConfigureBehavior(FeatureConfigurationFor<TContext> featureConfigurationFor)
        {
            _featureConfigurationFor = featureConfigurationFor;
        }

        public IFeatureConfiguration<TContext> Custom(ISupportContextFor<IControlFeatures, TContext> value)
        {
            Control.ConfigFor<TContext>().Set(value);
            return _featureConfigurationFor;
        }

        public IFeatureConfiguration<TContext> Custom(IControlFeatures value)
        {
            return Custom(new NoContextSupport<IControlFeatures, TContext>(value));
        }
    }

    internal class ConfigureNaming<TContext> : IConfigureNaming<TContext> where TContext : IContext
    {
        private readonly FeatureConfigurationFor<TContext> _featureConfigurationFor;

        public ConfigureNaming(FeatureConfigurationFor<TContext> featureConfigurationFor)
        {
            _featureConfigurationFor = featureConfigurationFor;
        }

        public IFeatureConfiguration<TContext> Custom(ISupportContextFor<IProvideNaming, TContext> value)
        {
            Control.ConfigFor<TContext>().Set(value);
            return _featureConfigurationFor;
        }

        public IFeatureConfiguration<TContext> Custom(IProvideNaming value)
        {
            return Custom(new NoContextSupport<IProvideNaming, TContext>(value));
        }
    }
}