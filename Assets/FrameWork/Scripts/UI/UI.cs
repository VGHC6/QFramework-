using FrameWork;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GamePassPanelEvent.Register(OnGameStartPanelEvent);
    }

    private void OnGameStartPanelEvent()
    {
        transform.Find("Canvas/GamepassPanel").gameObject.SetActive(true);
    }

    void OnDestroy()
    {
        GamePassPanelEvent.Unregister(OnGameStartPanelEvent);
    }
}
