using System;
using System.Collections.Generic;

namespace FeatureSwitcher.Configuration
{
    public static class FeatureConfiguration
    {
        private static readonly IDictionary<Type, object> Behaviors = new Dictionary<Type, object>();
        private static readonly IDictionary<Type, object> Namings = new Dictionary<Type, object>();

        internal static void Set<T, TControl>(InContextOf<T, TControl> value)
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

        public static FeatureControl For<T>(T context)
            where T : IContext
        {
            return new FeatureControl(BehaviorFor(context), NamingFor(context));
        }

        private static IProvideBehavior BehaviorFor<T>(T context)
            where T : IContext
        {
            return GetBehavior(context) ?? GetBehavior(Context.Default) ?? AllFeatures.Disabled;
        }

        private static IProvideNaming NamingFor<T>(T context)
            where T : IContext
        {
            return GetNaming(context) ?? GetNaming(Context.Default) ?? ProvideNaming.ByTypeFullName;
        }

        private static IProvideBehavior GetBehavior<T>(T context) where T : IContext
        {
            var contextType = typeof(T);
            object behavior;
            if (!Behaviors.TryGetValue(contextType, out behavior))
                return null;

            var inContextOf = behavior as InContextOf<T, IProvideBehavior>;
            return inContextOf != null ? inContextOf.With(context) : null;
        }

        private static IProvideNaming GetNaming<T>(T context) where T : IContext
        {
            var contextType = typeof(T);
            object naming;
            if (!Namings.TryGetValue(contextType, out naming))
                return null;

            var inContextOf = naming as InContextOf<T, IProvideNaming>;
            return inContextOf != null ? inContextOf.With(context) : null;
        }
    }
}