using System;

namespace FeatureSwitcher.Configuration
{
    public sealed class ContextConfigurations
    {
        public ContextConfiguration this[IContext context]
        {
            get { return new ContextConfiguration(context); }
        }
    }
}