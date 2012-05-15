using System;
using Contexteer;

namespace FeatureSwitcher.Configuration
{
    public interface IConfigureBehaviorFor<out TContext> : IConfigureBehavior
        where TContext : IContext
    {
        IConfigureFeaturesFor<TContext> Custom(Func<TContext, IProvideBehavior> behavior);
    }
}