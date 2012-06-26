using System;
using System.Collections.Generic;
using System.Linq;
using Contexteer;
using Contexteer.Configuration;

namespace FeatureSwitcher.Configuration
{
    public static class FeatureConfiguration
    {
        private static readonly IDictionary<Type, object> Behaviors = new Dictionary<Type, object>();
        private static readonly IDictionary<Type, object> Namings = new Dictionary<Type, object>();

        internal static void Set<T, TControl>(Func<T, TControl[]> value)
            where T : IContext
        {
            IDictionary<Type, object> configs;
            
            var controlType = typeof(TControl);
            if (typeof(IProvideBehavior).IsAssignableFrom(controlType))
                configs = Behaviors;
            else if (typeof(IProvideNaming).IsAssignableFrom(controlType))
                configs = Namings;
            else
                throw new NotSupportedException();
            
            var context = typeof(T);
            if (value != null)
                configs[context] = value;
            else
                configs.Remove(context);
        }

        public static IConfigureFeaturesFor<TContext> FeaturesAre<TContext>(this IConfigure<TContext> This)
            where TContext : IContext
        {
            return new FeatureConfigurationFor<TContext>();
        }

        public static ProvideState For<T>(T context)
            where T : IContext
        {
            return new ProvideState(BehaviorsFor(context), NamingsFor(context));
        }

        private static IEnumerable<IProvideBehavior> BehaviorsFor<T>(T context)
            where T : IContext
        {
            return GetBehaviors(context).Concat(GetBehaviors(Default.Context));
        }

        private static IEnumerable<IProvideNaming> NamingsFor<T>(T context)
            where T : IContext
        {
            return GetNamings(context).Concat(GetNamings(Default.Context));
        }

        private static IEnumerable<IProvideBehavior> GetBehaviors<T>(T context)
            where T : IContext
        {
            var contextType = typeof(T);
            object behavior;
            if (!Behaviors.TryGetValue(contextType, out behavior))
                return new IProvideBehavior[0];

            var inContextOf = behavior as Func<T, IProvideBehavior[]>;
            var provideBehaviors = inContextOf != null ? inContextOf(context) : null;
            return provideBehaviors ?? new IProvideBehavior[0];
        }

        private static IEnumerable<IProvideNaming> GetNamings<T>(T context)
            where T : IContext
        {
            var contextType = typeof(T);
            object naming;
            if (!Namings.TryGetValue(contextType, out naming))
                return new IProvideNaming[0];

            var inContextOf = naming as Func<T, IProvideNaming[]>;
            var provideNamings = inContextOf != null ? inContextOf(context) : null;
            return provideNamings ?? new IProvideNaming[0];
        }
    }
}