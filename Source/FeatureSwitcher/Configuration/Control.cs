using System;
using System.Collections.Generic;
using ContextSwitcher;

namespace FeatureSwitcher.Configuration
{
    internal static class Control
    {
        private static readonly ControlFeatures Default = new ControlFeatures();
        private static readonly IDictionary<Type, ControlFeatures> Contexts = new Dictionary<Type, ControlFeatures>();

        internal static ControlFeatures<TContext> For<TContext>() where TContext : IContext
        {
            var context = typeof (TContext);
            if (context == typeof(IContext))
                return Default;

            ControlFeatures result;
            if (!Contexts.TryGetValue(context, out result))
            {
                result = new ControlFeatures();
                Contexts.Add(context, result);
            }
            return result;
        }

        internal static bool IsEnabled<TContext>(TContext context, Type feature) where TContext : IContext
        {
            return For<TContext>().IsEnabled(context, feature);
        }
    }
}