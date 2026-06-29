using UnityEngine;
using UnityEngine.UI;

namespace FrameWork
{
    public class GameStartPanel : MonoBehaviour
    {
        [SerializeField] GameObject _gameObject;
        void Start()
        {
            transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener(() =>//委托
            {
                gameObject.SetActive(false);
                GameStartPanelEvent.Trigger();//触发事件
            }
            );
        }
    }
}