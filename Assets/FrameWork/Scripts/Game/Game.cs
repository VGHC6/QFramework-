using Framework;
using System;
using UnityEngine;

namespace FrameWork
{

    public class Game : MonoBehaviour
    {
        private void Awake()
        {
            GameStartPanelEvent.Register(OnGameStart);
            KillOneEnemyEvent.Register(KillOneEnemy);
        }

        private void OnDestroy()
        {
            GameStartPanelEvent.Unregister(OnGameStart);
            KillOneEnemyEvent.Unregister(KillOneEnemy);
        }

        private void OnGameStart()
        {
            transform.Find("enemies").gameObject.SetActive(true);
        }

        private void KillOneEnemy()
        {
            GameModel.KillCounter++;
            Debug.Log("KillCounter: " + GameModel.KillCounter);
            if (GameModel.KillCounter == 10)
            {
                GamePassPanelEvent.Trigger();
            }
        }
    }

}