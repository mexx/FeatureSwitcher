using System;
using System.Collections.Generic;

namespace FeatureSwitcher.Configuration
{
    internal static class Control
    {
        private static readonly ControlFeatures Default = new ControlFeatures();
        private static readonly IDictionary<IContext, ControlFeatures> Contexts = new Dictionary<IContext, ControlFeatures>();

        internal static ControlFeatures For(IContext context)
        {
            if (context == Context.Default)
                return Default;

            ControlFeatures result;
            if (!Contexts.TryGetValue(context, out result))
            {
                result = new ControlFeatures();
                Contexts.Add(context, result);
            }
            return result;
        }

        internal static bool IsEnabled(IContext context, Type feature)
        {
            return For(context).IsEnabled(feature);
        }
    }
}