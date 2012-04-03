namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public class Simple : IFeature
    {
        public static string FullName
        {
            get { return typeof (Simple).FullName; }
        }

        public static string Name
        {
            get { return typeof (Simple).Name; }
        }
    }

    public class Complex : IFeature
    {
        public static string FullName
        {
            get { return typeof (Complex).FullName; }
        }
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}