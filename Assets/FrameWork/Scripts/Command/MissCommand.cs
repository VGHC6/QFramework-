using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCommand : AbstructCommand
{
    protected override void OnExecute()
    {
        this.SendEvent<OnMissEvent>();
    }
}
