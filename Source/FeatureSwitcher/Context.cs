namespace FeatureSwitcher
{
    public static class Context
    {
        public static readonly IContext Default = new DefaultContext();
    }

    public static class Context<T>
        where T: IContext
    {
        public static InContextOf<T, TResult> Insensitive<TResult>(TResult value)
        {
            return new InsensitiveFor<T, TResult>(value);
        }
    }
}