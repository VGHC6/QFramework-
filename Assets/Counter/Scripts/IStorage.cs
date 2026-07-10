using UnityEditor;
using UnityEngine;

namespace Counter
{
    public interface IStorage:IUtility
    {
        public void SaveInt(string key, int defaultValue = 0);
        public int LoadInt(string key, int defaultValue = 0);
    }

    /// <summary>
    /// ÓÎÏ·´æ´¢
    /// </summary>
    public class PlayerStorage : IStorage
    {
        public int LoadInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public void SaveInt(string key, int defaultValue = 0)
        {
            PlayerPrefs.SetInt(key, defaultValue);
        }
    }

    /// <summary>
    /// ×é¼þ´æ´¢
    /// </summary>
    public class EditorStorage : IStorage
    {
        public int LoadInt(string key, int defaultValue = 0)
        {
#if UNITY_EDITOR
            return EditorPrefs.GetInt(key, defaultValue);
#endif
        }

        public void SaveInt(string key, int defaultValue = 0)
        {
#if UNITY_EDITOR
            EditorPrefs.SetInt(key, defaultValue);
#endif
        }
    }
}