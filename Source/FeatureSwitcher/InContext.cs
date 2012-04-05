namespace FeatureSwitcher
{
    public static class InContext
    {
        public static FeaturesInContextOf<T> Of<T>(T context)
            where T : IContext
        {
            return new FeaturesInContextOf<T>(context);
        }
    }
}