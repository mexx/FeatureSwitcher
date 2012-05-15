using System;

namespace FeatureSwitcher
{
    public sealed class StateOf<TFeature> : IStateOf<TFeature>
        where TFeature : IFeature
    {
        private readonly IProvideState _provideState;

        public StateOf(IProvideState provideState)
        {
            if (provideState == null)
                throw new ArgumentNullException("provideState");
            
            _provideState = provideState;
        }

        public bool Enabled
        {
            get { return _provideState.IsEnabled<TFeature>(); }
        }

        public bool Disabled
        {
            get { return !Enabled; }
        }
    }
}