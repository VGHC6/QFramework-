using Counter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAcheivementSystem : ISystem
{
}

public class AcheivementSystem : AbstactSystem, IAcheivementSystem
{
    protected override void OnInit()
    {
        var CounterModel = this.GetModel<IConterModel>();
        var previousCount = CounterModel.count.value;

        CounterModel.count._OnValueChanged += newCount =>
        {
            if (previousCount < 10 && newCount >= 10)
            {
                Debug.Log("You have reached 10!");
            }

        };
    }
}