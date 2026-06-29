using FrameWork;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Counter
{

    public class CounterViewController : MonoBehaviour
    {

        void Start()
        {
            CounterModel.count._OnValueChanged += UpDataView;

            // CounterChangedEvent.Register(UpDataView);
            //±íÏÖÂß¼­
            UpDataView(CounterModel.count.value);
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
               new AddCounterCommand().Execute();
            });

            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                new SubCounterCommand().Execute();
            });
        }

        private void OnDestroy()
        {
            //CounterChangedEvent.Unregister(UpDataView);
            CounterModel.count._OnValueChanged -= UpDataView;
        }

        void UpDataView(int newValue)
        {
            Debug.Log("UpDataView");
            transform.Find("Text").GetComponent<TMP_Text>().text = newValue.ToString();
        }

    }



    public class CounterModel
    {
        public static BindProerty<int> count = new BindProerty<int>
        {
            value = 0
        };
    }




    //public class CounterChangedEvent : Event<CounterChangedEvent>
    //{

    //}
}
