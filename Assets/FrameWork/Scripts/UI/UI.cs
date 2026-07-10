using UnityEngine;

namespace Framework
{


    public class UI : MonoBehaviour, IController
    {
        // Start is called before the first frame update
        void Awake()
        {
            this.RegisterEvent<GamePassPanelEvent>(OnGameStartPanelEvent);
        }

        private void OnGameStartPanelEvent(GamePassPanelEvent e)
        {
            transform.Find("Canvas/GamepassPanel").gameObject.SetActive(true);
        }

        void OnDestroy()
        {
            this.UnRegisterEvent<GamePassPanelEvent>(OnGameStartPanelEvent);
        }

        public IArchitecture _GetArchitecture()
        {
            return PointGame.Interface;
        }
    }
}