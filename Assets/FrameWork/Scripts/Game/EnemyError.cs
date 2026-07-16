using Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyError : MonoBehaviour,IController
{
    public IArchitecture _GetArchitecture()
    {
        return PointGame.Interface;
    }

    private void OnMouseDown()
    {
        this.SendCommand<MissCommand>();
    }
}
