using System;
using Contexteer;

namespace FeatureSwitcher.Configuration
{
    public interface IConfigureNamingFor<out TContext> : IConfigureNaming
        where TContext : IContext
    {
        IConfigureFeaturesFor<TContext> Custom(Func<TContext, IProvideNaming> naming);
    }
}