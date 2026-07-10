using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanSendEvent : IBelongArchitecture
{

}

public static class CanSendEventExtention
{
    public static void SendEvent<T>(this ICanSendEvent self) where T : new()
    {
        self._GetArchitecture().SendEvent<T>();
    }

    public static void SendEvent<T>(this ICanSendEvent self, T t)
    {
        self._GetArchitecture().SendEvent<T>(t);
    }
}
