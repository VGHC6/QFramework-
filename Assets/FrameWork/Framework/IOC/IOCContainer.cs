using System;
using System.Collections.Generic;

public class IOCContainer
{
    private Dictionary<Type, object> _instance = new Dictionary<Type, object>();

    /// <summary>
    /// ×¢²á
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="instance"></param>
    public void Register<T>(T instance)
    {
        var key = typeof(T);
        if (_instance.ContainsKey(key))
        {
            _instance[key] = instance;
        }
        else
        {
            _instance.Add(key, instance);
        }
    }

    /// <summary>
    /// µÃµ½value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Get<T>() where T : class
    {
        var key = typeof(T);
        if (_instance.TryGetValue(key, out var result))
        {
            return result as T;
        }
        return null;
    }
}
