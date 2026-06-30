using System;
using System.Reflection;

public class Singleton<T> where T:Singleton<T>
{
    private static T _instance;

    /// <summary>
    /// 要求子类必须有一个无参构造函数
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                var type = typeof(T);//获取类型
                var ctors= type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);//获取私有构造函数
                var ctor=Array.Find(ctors, c => c.GetParameters().Length == 0);//获取无参构造函数

                if (ctor == null)
                {
                    throw new Exception("No private constructor found"+ type.Name);
                }

                _instance= ctor.Invoke(null) as T;//实例化
            }
            return _instance;
        }
    }
}
