namespace FeatureSwitcher.Configuration.Internal
{
    internal interface IControlContextsOfType<out T>
        where T : IContext
    {
        void Set<TControl>(InContextOf<T, TControl> value);
    }
}