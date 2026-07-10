using UnityEngine;

namespace Framework
{

    public class Game : MonoBehaviour, IController
    {
        public IArchitecture _GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void Awake()
        {
            this.RegisterEvent<GameStartPanelEvent>(OnGameStart);
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<GameStartPanelEvent>(OnGameStart);
        }

        private void OnGameStart(GameStartPanelEvent e)
        {
            transform.Find("enemies").gameObject.SetActive(true);
        }

    }

}