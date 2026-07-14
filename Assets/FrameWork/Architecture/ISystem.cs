using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISystem : IBelongArchitecture, ICanSetArchitecture, ICanGetModel,ICanSendEvent,ICanRegisterEvent
{
    void Init();
}

public abstract class AbstactSystem : ISystem
{
    private IArchitecture _architecture;
    void ISystem.Init()
    {
        OnInit();
    }

    protected abstract void OnInit();

    void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
    {
        _architecture = architecture;
    }

    IArchitecture IBelongArchitecture._GetArchitecture()
    {
        return _architecture;
    }
}
