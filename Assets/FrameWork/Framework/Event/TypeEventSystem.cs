using Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using static TypeEventSystem;

public interface ITypeEventSystem
{
    void Send<T>() where T : new();//����
    void Send<T>(T t);//����
    UnRegisterEvent Register<T>(Action<T> OnEvent);//ע��
    void UnRegister<T>(Action<T> OnEvent);//ȡ��ע��
}

/// <summary>
/// ȡ��ע���¼�
/// </summary>
public interface UnRegisterEvent
{
    void UnRegister();
}

/// <summary>
/// ȡ��ע���¼����ӿ�ʵ��
/// </summary>
/// <typeparam name="T"></typeparam>
public class TypeEventSystemUnRegister<T> : UnRegisterEvent
{
    public ITypeEventSystem _typeEventSystem;
    public Action<T> _onEvent;
    public void UnRegister()
    {
        _typeEventSystem.UnRegister<T>(_onEvent);
        _typeEventSystem = null;
        _onEvent = null;
    }
}

/// <summary>
/// ȡ��ע���¼���һ��ȡ��
/// </summary>
public class UnRegisterEventTrigger : MonoBehaviour
{
    HashSet<UnRegisterEvent> _unRegisterEvents = new HashSet<UnRegisterEvent>();

    public void AddUnRegister(UnRegisterEvent unRegisterEvent)
    {
        _unRegisterEvents.Add(unRegisterEvent);
    }

    private void OnDestroy()
    {
        foreach (var unRegisterEvent in _unRegisterEvents)
        {
            unRegisterEvent.UnRegister();
        }

        _unRegisterEvents.Clear();
    }
}

/// <summary>
/// ȡ��ע���¼�,
/// </summary>
public static class UnRegisterEventExtension
{
    public static void UnRegisterWhenGameObjectDEstory(this UnRegisterEvent unRegisterEvent, GameObject gameObject)
    {
        var tirgger = gameObject.GetComponent<UnRegisterEventTrigger>();
        if (!tirgger)
        {
            tirgger = gameObject.AddComponent<UnRegisterEventTrigger>();
        }

        tirgger.AddUnRegister(unRegisterEvent);
    }
}



/// <summary>
/// �¼�ϵͳ
/// </summary>
public class TypeEventSystem : ITypeEventSystem
{
    public interface IRegistors
    {

    }

    public class Registors<T> : IRegistors
    {
        public Action<T> OnEvent = e => { };
    }

    Dictionary<Type, IRegistors> _Eventregistors = new Dictionary<Type, IRegistors>();
    public UnRegisterEvent Register<T>(Action<T> OnEvent)
    {
        var type = typeof(T);
        IRegistors registors;
        if (_Eventregistors.TryGetValue(type, out registors))
        {

        }
        else
        {
            registors = new Registors<T>();
            _Eventregistors.Add(type, registors);
        }

        (registors as Registors<T>).OnEvent += OnEvent;
        return new TypeEventSystemUnRegister<T> { _typeEventSystem = this, _onEvent = OnEvent };
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
            (registors as Registors<T>).OnEvent(t);
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

