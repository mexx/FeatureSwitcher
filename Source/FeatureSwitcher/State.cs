using System;
using System.Reflection;

namespace FeatureSwitcher
{
    public static class State
    {
        private static readonly MethodInfo OfMethod;

        static State()
        {
            OfMethod = typeof(State).GetMethod("Of", new Type[0]);
        }

        public static IIncompleteOf<TFeature> Of<TFeature>()
            where TFeature: IFeature
        {
            return new IncompleteOf<TFeature>();
        }

        public static IIncompleteOf<TFeature> Of<TFeature>(Type featureType)
            where TFeature : IFeature
        {
            return (IIncompleteOf<TFeature>)OfMethod.MakeGenericMethod(new[] { featureType }).Invoke(null, new object[0]);
        }

        public interface IIncompleteOf<out TFeature>
            where TFeature : IFeature
        {
            IStateOf<TFeature> With(IProvideState provideState);
        }

        class IncompleteOf<TFeature> : IIncompleteOf<TFeature>
            where TFeature : IFeature
        {
            public IStateOf<TFeature> With(IProvideState provideState)
            {
                return new StateOf<TFeature>(provideState);
            }
        }
    }
}