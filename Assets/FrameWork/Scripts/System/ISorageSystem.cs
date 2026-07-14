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
            gameModel.score.value = Random.Range(0, 100);
            if (gameModel.KillCounter.value >= gameModel.score.value)
            {
                gameModel.score.value = gameModel.KillCounter.value;
            }
        });
    }
}