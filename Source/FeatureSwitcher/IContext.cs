namespace ContextSwitcher
{
    public interface IContext
    {
    }

    public static class Context
    {
        public static readonly IContext Default = null;
    }

    public interface ISupportContextFor<out TResult, in TContext> where TContext : IContext
    {
        TResult With(TContext context);
    }

    public sealed class NoContextSupport<T, TContext> : ISupportContextFor<T, TContext> where TContext : IContext
    {
        private readonly T _result;

        public NoContextSupport(T result)
        {
            _result = result;
        }

        public T With(TContext context)
        {
            return _result;
        }
    }
}
