using UnityEngine;

namespace Framework
{
    public class Enemy : MonoBehaviour, IController
    {
        public GameObject _gameObject;

        public void OnMouseDown()
        {
            Debug.Log("Enemy clicked");
            this.SendCommand<KillOneCommand>();

            Destroy(gameObject);
        }

        IArchitecture IBelongArchitecture._GetArchitecture()
        {
            return PointGame.Interface;
        }
    }
}