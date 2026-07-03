using Counter;
using System;
using UnityEditor;
using UnityEngine;

namespace Counter
{
    public class CounterAppEditor : EditorWindow
    {
        [MenuItem("CounterApp/Open")]
      static void Open()
        {
            var Window = GetWindow<CounterAppEditor>();
            Window.position= new Rect(100,100,400,500);
            Window.titleContent = new GUIContent("CounterApp");
            Window.Show();
        }
        
        private void OnGUI()
        {
            if (GUILayout.Button("Add"))
            {
               new AddCounterCommand().Execute();
            }

            GUILayout.Label(CounterApp.Get<IConterModel>().count.value.ToString());

            if (GUILayout.Button("Sub"))
            {
               new SubCounterCommand().Execute();
            }
        }
    }
}