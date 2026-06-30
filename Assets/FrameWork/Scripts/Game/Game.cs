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
        }

        private void OnDestroy()
        {
            GameStartPanelEvent.Unregister(OnGameStart);
        }

        private void OnGameStart()
        {
            transform.Find("enemies").gameObject.SetActive(true);
        }

    }

}