namespace FeatureSwitcher.Specs
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local
    public interface IComponent : IFeature
    {        
    }

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

    public class Complex : IComponent
    {
        public static string FullName
        {
            get { return typeof (Complex).FullName; }
        }
    }

    public class Basic : IFeature
    {
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore InconsistentNaming
}