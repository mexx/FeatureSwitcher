using System;
using ContextSwitcher;
using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher.Configuration
{
    internal class ControlFeatures<TContext> where TContext : IContext
    {
        private ISupportContextFor<IControlFeatures, TContext> _behavior;
        private ISupportContextFor<IProvideNaming, TContext> _naming;

        public bool IsEnabled(TContext context, Type feature)
        {
            return Behavior.With(context).IsEnabled(Naming.With(context).For(feature));
        }

        public ISupportContextFor<IControlFeatures, TContext> Behavior
        {
            get { return _behavior ?? new NoContextSupport<IControlFeatures, TContext>(AllFeatures.Disabled); }
            set { _behavior = value; }
        }

        public ISupportContextFor<IProvideNaming, TContext> Naming
        {
            get { return _naming ?? new NoContextSupport<IProvideNaming, TContext>(Use.Type.FullName); }
            set { _naming = value ; }
        }
    }
}