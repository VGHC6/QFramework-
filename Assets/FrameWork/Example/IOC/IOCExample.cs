using UnityEngine;
using System;

namespace FrameWork
{
    public class IOCExample : MonoBehaviour
    {
        void Start()
        {
            var container = new IOCContainer();
            container.Register(new BuleConnect());

            var blue = container.Get<BuleConnect>();
            blue.Connect();
        }
    }

    public class BuleConnect
    {
        public void Connect()
        {
            Debug.Log("BuleConnect");
        }
    }
}