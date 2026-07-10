using Counter;
using UnityEngine;
using UnityEngine.UI;

namespace Framework
{
    public class GameStartPanel : MonoBehaviour, IController
    {
        [SerializeField] GameObject _gameObject;

        IArchitecture IBelongArchitecture._GetArchitecture()
        {
            return PointGame.Interface;
        }

        void Start()
        {
            transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.SendCommand<GameStartCommand>();
                gameObject.SetActive(false);
            }
            );
        }
    }
}