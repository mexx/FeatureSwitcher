namespace FeatureSwitcher
{
    public interface IContext
    {
    }

    public static class Context
    {
        public static readonly IContext Default = null;
    }

    public interface IInContextOf<in T, out TResult> where T : IContext
    {
        TResult With(T context);
    }

    public static class NoContext<T> where T : IContext
    {
        public static IInContextOf<T, TResult> SupportFor<TResult>(TResult result)
        {
            return new NoContextSupport<T, TResult>(result);
        }

        private sealed class NoContextSupport<TContext, TResult> : IInContextOf<TContext, TResult> where TContext : IContext
        {
            private readonly TResult _result;

            public NoContextSupport(TResult result)
            {
                _result = result;
            }

            public TResult With(TContext context)
            {
                return _result;
            }
        }
    }
}
