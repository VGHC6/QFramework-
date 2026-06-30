using Framework;
using UnityEngine;

namespace FrameWork
{
    public class Enemy : MonoBehaviour
    {
        public GameObject _gameObject;
        public void OnMouseDown()
        {
            Debug.Log("Enemy clicked");
            new KillOneCommand().Execute();
            Destroy(gameObject);
        }
    }
}