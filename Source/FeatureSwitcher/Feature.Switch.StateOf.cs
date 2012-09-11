using System;
using FeatureSwitcher.Configuration;

namespace FeatureSwitcher
{
    public static partial class Feature
    {
        public static partial class Switch
        {
            public class StateOf<T> : IKnowStateOf<T>
                where T : IFeature
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
                    get { return _provideState.IsEnabled<T>(); }
                }

                public bool Disabled
                {
                    get { return !Enabled; }
                }
            }
        }
    }
}