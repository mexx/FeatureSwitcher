using System;
using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher.Configuration
{
    internal class ControlFeatures: IConfigureBehavior, IConfigureNaming
    {
        private IControlFeatures _behavior;
        private IProvideFeatureNames _naming;

        public bool IsEnabled(Type feature)
        {
            return Behavior.IsEnabled(Naming.For(feature));
        }

        public IControlFeatures Behavior
        {
            get { return _behavior ?? AllFeatures.Disabled; }
            set { _behavior = value; }
        }

        public IProvideFeatureNames Naming
        {
            get { return _naming ?? Use.Type.FullName; }
            set { _naming = value ; }
        }
    }
}