using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanGetSystem : IBelongArchitecture
{

}

public static class CanGetSystem
{
    public static T GetSystem<T>(this ICanGetSystem self) where T : class, ISystem
    {
        return self._GetArchitecture().GetSystem<T>();
    }
}