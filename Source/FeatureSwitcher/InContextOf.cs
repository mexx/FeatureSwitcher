namespace FeatureSwitcher
{
    // ReSharper disable InconsistentNaming
    public interface InContextOf<in T, out TResult>
        where T : IContext
    // ReSharper restore InconsistentNaming
    {
        TResult With(T context);
    }
}