using System;
using System.Collections.Generic;

namespace FeatureSwitcher.Configuration.Internal
{
    internal static class FeatureConfiguration
    {
        private static readonly IDictionary<Type, object> Contexts = new Dictionary<Type, object>();

        internal static IControlContextsOfType<T> SettingsFor<T>()
            where T : IContext
        {
            var context = typeof (T);

            object result;
            if (!Contexts.TryGetValue(context, out result))
            {
                result = new ControlContextsOfType<T>();
                Contexts.Add(context, result);
            }
            return (IControlContextsOfType<T>)result;
        }

        internal static IControlFeatureInContextsOfType<T> For<T>()
            where T : IContext
        {
            object result;
            var control = Contexts.TryGetValue(typeof(T), out result) ? result : new ControlContextsOfType<T>();
            return control as IControlFeatureInContextsOfType<T>;
        }
    }
}