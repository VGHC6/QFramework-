using System;
using System.Collections.Generic;

public interface IArchitecture
{
    T GetUtility<T>() where T : class;//获取工具
    T GetModel<T>() where T : class, IUtility;//获取模型
    T GetSystem<T>() where T : class, ISystem;//获取系统
    void RegisterSystem<T>(T system) where T : ISystem;//注册系统
    void RegisterUtility<T>(T instance) where T : IMode;//注册工具
    void RegisterModel<T>(T instance) where T : IUtility;//注册模型
    void SendCommand<T>() where T : ICommand, new();//发送命令
    void SendCommand<T>(T command) where T : ICommand;//发送命令
    void SendEvent<T>() where T : new();//发送事件
    void SendEvent<T>(T t);//发送事件
    UnRegisterEvent Register<T>(Action<T> OnEvent);//注册事件
    void UnRegister<T>(Action<T> OnEvent);//取消注册事件
}




public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
{
    /// <summary>
    /// 是否初始化
    /// </summary>
    private bool is_Init = false;
    private List<IMode> _modeList = new List<IMode>();//模式列表
    private List<ISystem> _systemList = new List<ISystem>();//系统列表
    private static T _architecture;


    public static Action<T> OnRegisterAction = architecture => { };

    /// <summary>
    /// 初始化
    /// </summary>
    public static IArchitecture Interface
    {
        get
        {
            if (_architecture == null)
            {
                MakeSureArchitecture();
            }
            return _architecture;
        }
    }


    /// <summary>
    /// 确保不空
    /// </summary>
    static void MakeSureArchitecture()
    {
        if (_architecture == null)
        {
            _architecture = new T();
            _architecture.init();
            OnRegisterAction?.Invoke(_architecture);
        }


        foreach (var item in _architecture._modeList)
        {
            item.Init();//初始化
        }

        _architecture._modeList.Clear();
        _architecture.is_Init = true;//初始化完成


        foreach (var item in _architecture._systemList)
        {
            item.Init();//初始化
        }

        _architecture._systemList.Clear();
        _architecture.is_Init = true;//初始化完成
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
    public static void Register<T>(T instance)
    {
        MakeSureArchitecture();
        _architecture._iocContainer.Register<T>(instance);
    }


    /// <summary>
    /// 注册工具
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="instance"></param>
    public void RegisterUtility<T>(T instance) where T : IMode
    {
        instance.SetArchitecture(this);
        _iocContainer.Register<T>(instance);

        if (!is_Init)
        {
            _modeList.Add(instance);//添加到模式列表
        }
        else
        {
            instance.Init();//初始化
        }
    }

    /// <summary>
    /// 注册模型
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <param name="instance"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    public void RegisterModel<T>(T instance) where T : IUtility
    {
        _iocContainer.Register<T>(instance);
    }

    /// <summary>
    /// 注册系统
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <exception cref="NotImplementedException"></exception>
    public void RegisterSystem<T>(T system) where T : ISystem
    {
        system.SetArchitecture(this);
        _iocContainer.Register<T>(system);

        if (!is_Init)
        {
            _systemList.Add(system);//添加到模式列表
        }
        else
        {
            system.Init();//初始化
        }
    }


    /// <summary>
    /// 获取工具
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetUtility<T>() where T : class
    {
        return _iocContainer.Get<T>();
    }

    public T GetModel<T>() where T : class, IUtility
    {
        return _iocContainer.Get<T>();
    }

    public void SendCommand<T>() where T : ICommand, new()
    {
        var command = new T();
        command.SetArchitecture(this);
        command.Execute();
        //command.SetArchitecture(null);
    }

    public void SendCommand<T>(T command) where T : ICommand
    {
        command.SetArchitecture(this);
        command.Execute();
    }

    public T GetSystem<T>() where T : class, ISystem
    {
        return _iocContainer.Get<T>();
    }


    private TypeEventSystem _typeEventSystem = new TypeEventSystem();//事件系统

    public void SendEvent<T>() where T : new()
    {
        _typeEventSystem.Send<T>();
    }

    public void SendEvent<T>(T t)
    {
        _typeEventSystem.Send<T>(t);
    }

    public UnRegisterEvent Register<T>(Action<T> OnEvent)
    {
        return _typeEventSystem.Register<T>(OnEvent);
    }

    public void UnRegister<T>(Action<T> OnEvent)
    {
        _typeEventSystem.UnRegister<T>(OnEvent);
    }
}
