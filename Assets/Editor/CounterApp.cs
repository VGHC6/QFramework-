using UnityEditor;
using UnityEngine;

namespace Counter
{
    public class CounterAppEditor : EditorWindow, IController
    {
        [MenuItem("CounterApp/Open")]
        static void Open()
        {
            CounterApp.OnRegisterAction += app =>
            {
                app.RegisterModel<IStorage>(new EditorStorage());
            };


            var Window = GetWindow<CounterAppEditor>();
            Window.position = new Rect(100, 100, 400, 500);
            Window.titleContent = new GUIContent("CounterApp");
            Window.Show();
        }

        IArchitecture IBelongArchitecture._GetArchitecture()
        {
            return CounterApp.Interface;
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Add"))
            {
                this.SendCommand<AddCounterCommand>();
            }

            GUILayout.Label(CounterApp.Get<IConterModel>().count.value.ToString());

            if (GUILayout.Button("Sub"))
            {
                this.SendCommand<SubCounterCommand>();
            }
        }
    }
}