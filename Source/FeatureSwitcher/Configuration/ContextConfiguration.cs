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

        public IFeatureConfiguration<TContext> WithFeatures
        {
            get { return new FeatureConfigurationFor<TContext>(); }
        }
    }

    public static class Always
    {
        public static IFeatureConfiguration<TContext> AlwaysEnabled<TContext>(this IFeatureConfiguration<TContext> This) where TContext : IContext
        {
            This.ConfiguredBy.Set(AllFeatures.Enabled);
            return This;
        }

        public static IFeatureConfiguration<TContext> AlwaysDisabled<TContext>(this IFeatureConfiguration<TContext> This) where TContext : IContext
        {
            This.ConfiguredBy.Set(AllFeatures.Disabled);
            return This;
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
            get { return new ConfigureNaming<TContext>(); }
        }

        public IConfigureBehavior<TContext> ConfiguredBy
        {
            get { return new ConfigureBehavior<TContext>(); }
        }
    }

    internal class ConfigureBehavior<TContext> : IConfigureBehavior<TContext> where TContext : IContext
    {
        public void Set(IControlFeatures value)
        {
            Control.For<TContext>().Behavior = value;
        }
    }

    internal class ConfigureNaming<TContext> : IConfigureNaming<TContext> where TContext : IContext
    {
        public void Set(IProvideNaming value)
        {
            Control.For<TContext>().Naming = value;
        }
    }
}