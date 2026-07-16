using Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISorageSystem : ISystem
{

}

public class StorageSystem : AbstactSystem, ISorageSystem
{
    protected override void OnInit()
    {
        var gameModel = this.GetModel<IGameModel>();

        this.RegisterEvent<GamePassPanelEvent>(e =>
        {
            if (gameModel.KillCounter.value >= gameModel.score.value)
            {
                gameModel.score.value = gameModel.KillCounter.value;
            }
        });


        this.RegisterEvent<OnEnemyKillEvent>(e =>
        {
            gameModel.score.value += 10;
        });

        this.RegisterEvent<OnMissEvent>(e =>
        {
            gameModel.score.value -= 10;
            //Debug.Log("miss");
        });
    }
}