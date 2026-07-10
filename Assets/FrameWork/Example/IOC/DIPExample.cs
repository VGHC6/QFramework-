using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
namespace Framework
{
    public class DIPExample : MonoBehaviour
    {
        public interface IStorage
        {
            void StorageString(string Key, string Value);
            string LoadString(string Key, string DefaultValue="");
        }

        public class PalyerfabsStorage : IStorage
        {
            public string LoadString(string Key, string DefaultValue = "")
            {
               return PlayerPrefs.GetString(Key, DefaultValue);
            }

            public void StorageString(string Key, string Value)
            {
                PlayerPrefs.SetString(Key, Value);
            }
        }


        public class EditorStorage : IStorage
        {
            public string LoadString(string Key, string DefaultValue = "")
            {
               return EditorPrefs.GetString(Key, DefaultValue);
            }

            public void StorageString(string Key, string Value)
            {
                EditorPrefs.SetString(Key, Value);
            }
        }


        private void Start()
        {
            var Container= new IOCContainer();
            Container.Register<IStorage>(new PalyerfabsStorage());
            var storage = Container.Get<IStorage>();

            storage.StorageString("name", "zhangsan");
            Debug.Log(storage.LoadString("name"));

            Container.Register<IStorage>(new EditorStorage());

            storage = Container.Get<IStorage>();
            storage.StorageString("name", "lisi");
            Debug.Log(storage.LoadString("name"));

        }
    }
}