public abstract class Architecture<T> where T : Architecture<T>, new()
{
    private static T _architecture;

    static void MakeSureArchitecture()
    {
        if (_architecture == null)
        {
            _architecture = new T();
            _architecture.init();
        }
    }

    protected abstract void init();//子类接口

    private IOCContainer _iocContainer = new IOCContainer();//单例容器

    /// <summary>
    /// 得到
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Get<T>() where T : class
    {
        MakeSureArchitecture();
        return _architecture._iocContainer.Get<T>();
    }

    /// <summary>
    /// 注册
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="instance"></param>
    public void Register<T>(T instance)
    {
        MakeSureArchitecture();
        _architecture._iocContainer.Register<T>(instance);
    }

}
