using UnityEngine;
using UnityEngine.UI;

namespace FrameWork
{
    public class GameStartPanel : MonoBehaviour
    {
        [SerializeField] GameObject _gameObject;
        void Start()
        {
            transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener(() =>//Î¯ÍÐ
            {
                gameObject.SetActive(false);
                new GameStartCommand().Execute();
            }
            );
        }
    }
}