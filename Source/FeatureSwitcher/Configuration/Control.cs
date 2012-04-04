using System;
using System.Collections.Generic;

namespace FeatureSwitcher.Configuration
{
    internal static class Control
    {
        private static readonly ControlContext Default = new ControlContext();
        private static readonly IDictionary<IContext, ControlContext> Contexts = new Dictionary<IContext, ControlContext>();

        internal static ControlContext For(IContext context)
        {
            if (context == Context.Default)
                return Default;

            ControlContext result;
            if (!Contexts.TryGetValue(context, out result))
            {
                result = new ControlContext();
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