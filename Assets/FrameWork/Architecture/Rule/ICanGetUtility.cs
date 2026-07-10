public interface ICanGetUtility : IBelongArchitecture
{
}


public static class CanGetUtility
{
    public static T GetUtility<T>(this ICanGetUtility self) where T : class, IUtility
    {
        return self._GetArchitecture().GetModel<T>();
    }
}