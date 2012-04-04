using System;
using FeatureSwitcher.Behaviors.Internal;

namespace FeatureSwitcher.Configuration
{
    public sealed class ContextConfiguration
    {
        private readonly IContext _context;

        internal ContextConfiguration(IContext context)
        {
            _context = context;
        }

        public IFeatureConfiguration WithFeatures
        {
            get { return new FeatureConfigurationFor(_context); }
        }
    }

    internal class FeatureConfigurationFor : IFeatureConfiguration
    {
        private readonly IContext _context;

        public FeatureConfigurationFor(IContext context)
        {
            _context = context;
        }

        public IFeatureConfiguration AlwaysEnabled()
        {
            ConfiguredBy.Behavior = AllFeatures.Enabled;
            return this;
        }

        public IFeatureConfiguration AlwaysDisabled()
        {
            ConfiguredBy.Behavior = AllFeatures.Disabled;
            return this;
        }

        public IFeatureConfiguration And
        {
            get { return this; }
        }

        public IConfigureNaming NamedBy
        {
            get { return Control.For(_context); }
        }

        public IConfigureBehavior ConfiguredBy
        {
            get { return Control.For(_context); }
        }
    }
}