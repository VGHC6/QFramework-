using System;
using System.Collections.Generic;
using UnityEngine;

public interface ITypeEventSystem
{
    void Send<T>() where T : new();//发送事件，无参数，自动new一个事件对象
    void Send<T>(T t);//发送事件，带参数
    UnRegisterEvent Register<T>(Action<T> OnEvent);//注册监听
    void UnRegister<T>(Action<T> OnEvent);//取消监听
}

/// <summary>
/// 定义注销接口
/// </summary>
public interface UnRegisterEvent
{
    void UnRegister();
}

/// <summary>
/// 具体注销器
/// </summary>
/// <typeparam name="T"></typeparam>
public class TypeEventSystemUnRegister<T> : UnRegisterEvent
{
    public ITypeEventSystem _typeEventSystem;//持有事件系统的引用
    public Action<T> _onEvent;//持有委托引用
    public void UnRegister()
    {
        _typeEventSystem.UnRegister<T>(_onEvent);//主动解绑
        _typeEventSystem = null;
        _onEvent = null;
    }
}

/// <summary>
/// 挂在 GameObject 上，OnDestroy 时批量注销
/// </summary>
public class UnRegisterEventTrigger : MonoBehaviour
{
    HashSet<UnRegisterEvent> _unRegisterEvents = new HashSet<UnRegisterEvent>();//存储所有注销器

    public void AddUnRegister(UnRegisterEvent unRegisterEvent)
    {
        _unRegisterEvents.Add(unRegisterEvent);
    }

    private void OnDestroy()
    {
        foreach (var unRegisterEvent in _unRegisterEvents)
        {
            unRegisterEvent.UnRegister();// 对象销毁时全部解绑
        }

        _unRegisterEvents.Clear();
    }
}

/// <summary>
/// 扩展方法：绑定生命周期
/// </summary>
public static class UnRegisterEventExtension
{
    public static void UnRegisterWhenGameObjectDEstory(this UnRegisterEvent unRegisterEvent, GameObject gameObject)
    {
        // 自动添加/获取 UnRegisterEventTrigger 组件
        var tirgger = gameObject.GetComponent<UnRegisterEventTrigger>();
        if (!tirgger)
        {
            tirgger = gameObject.AddComponent<UnRegisterEventTrigger>();
        }

        tirgger.AddUnRegister(unRegisterEvent);
    }
}



/// <summary>
/// 核心实现
/// </summary>
public class TypeEventSystem : ITypeEventSystem
{
    public interface IRegistors//空接口，仅用于统一存储
    {

    }

    public class Registors<T> : IRegistors//内部类，持有 Action<T> 委托链，默认空避免 null 检查
    {
        public Action<T> OnEvent = e => { };
    }

    Dictionary<Type, IRegistors> _Eventregistors = new Dictionary<Type, IRegistors>();//用类型做 Key 查找注册器
                                                                                      //Value 是 IRegistos 空接口，实际存入的是 Registors<T>
                                                                                      //这样就能在一个 Dictionary 里统一存储不同泛型参数的 Registors<T>
    public UnRegisterEvent Register<T>(Action<T> OnEvent)
    {
        var type = typeof(T);// 拿 Type 作为 Key
        IRegistors registors;
        if (_Eventregistors.TryGetValue(type, out registors))
        {

        }
        else
        {
            registors = new Registors<T>();//没有就创建
            _Eventregistors.Add(type, registors);
        }

        (registors as Registors<T>).OnEvent += OnEvent;//挂接委托
        return new TypeEventSystemUnRegister<T> { _typeEventSystem = this, _onEvent = OnEvent };//返回注销器
    }

    public void Send<T>() where T : new()
    {
        var t=new T();
        Send<T>(t);
    }

    public void Send<T>(T t)
    {
        var type = typeof(T);
        IRegistors registors;
        if (_Eventregistors.TryGetValue(type, out registors))
        {
            (registors as Registors<T>).OnEvent(t);// 调用委托链
        }
    }


    public void UnRegister<T>(Action<T> OnEvent)
    {
        var type = typeof(T);
        IRegistors registors;
        if (_Eventregistors.TryGetValue(type, out registors))
        {
            (registors as Registors<T>) .OnEvent -= OnEvent;
        }
    }
}

