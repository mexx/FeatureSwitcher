namespace FeatureSwitcher
{
    internal sealed class InsensitiveFor<TContext, TResult> : InContextOf<TContext, TResult>
        where TContext : IContext
    {
        private readonly TResult _result;

        public InsensitiveFor(TResult result)
        {
            _result = result;
        }

        public TResult With(TContext context)
        {
            return _result;
        }
    }
}