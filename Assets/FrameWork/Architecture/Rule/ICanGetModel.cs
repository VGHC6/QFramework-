using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanGetModel : IBelongArchitecture
{
}

public static class CabGetModel
{
    public static T GetModel<T>(this ICanGetModel self) where T : class, IMode
    {
        return self._GetArchitecture().GetUtility<T>();
    }
}
