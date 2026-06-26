using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

namespace FrameWork
{
    public class Enemy : MonoBehaviour
    {
        public GameObject _gameObject;
        static int Counter = 0;//È«¾Ö
        public void OnMouseDown()
        {
            Destroy(gameObject);
            Counter++;
            Debug.Log(Counter);
            if (Counter == 10)
            {
                Debug.Log("You Win");
                _gameObject.SetActive(true);
            }

        }
    }
}