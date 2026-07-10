using System;
using UnityEngine;

public interface ICanRegisterEvent : IBelongArchitecture
{

}

public static class ICanRegisterEventExtension
{
    public static UnRegisterEvent RegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent) where T : new()
    {
        return self._GetArchitecture().Register<T>(onEvent);
    }

    public static void UnRegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent) where T : new()
    {
        self._GetArchitecture().UnRegister<T>(onEvent);
    }
}