using System;
using System.Collections.Generic;

namespace FeatureSwitcher.Configuration
{
    internal static class Control
    {
        private static readonly ControlContexts<IContext> Default = new ControlContexts<IContext>();
        private static readonly IDictionary<Type, object> Contexts = new Dictionary<Type, object>();

        static Control()
        {
            Contexts.Add(typeof(IContext), Default);
        }

        internal static IControlContexts<TContext> ConfigFor<TContext>() where TContext : IContext
        {
            var context = typeof (TContext);

            object result;
            if (!Contexts.TryGetValue(context, out result))
            {
                result = new ControlContexts<TContext>();
                Contexts.Add(context, result);
            }
            return (IControlContexts<TContext>)result;
        }

        internal static IControlFeatureInContexts<TContext> For<TContext>() where TContext : IContext
        {
            var context = typeof(TContext);

            object result;
            var control = Contexts.TryGetValue(context, out result) ? result : Default;
            return control as IControlFeatureInContexts<TContext>;
        }

        internal static bool IsEnabled<TFeature, TContext>(TContext context)
            where TFeature : IFeature
            where TContext : IContext
        {
            return For<TContext>().IsEnabled<TFeature>(context);
        }
    }
}