using FrameWork;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Counter
{

    public class CounterViewController : MonoBehaviour
    {
        private CounterModel _counterModel;
        void Start()
        {
            _counterModel=CounterApp.Get<CounterModel>();

            _counterModel.count._OnValueChanged += UpDataView;

            // CounterChangedEvent.Register(UpDataView);
            //±íÏÖÂß¼­
            UpDataView(_counterModel.count.value);
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
            _counterModel.count._OnValueChanged -= UpDataView;
        }

        void UpDataView(int newValue)
        {
            Debug.Log("UpDataView");
            transform.Find("Text").GetComponent<TMP_Text>().text = newValue.ToString();
        }

    }



    public class CounterModel
    {
        public BindProerty<int> count = new BindProerty<int>
        {
            value = 0
        };
    }




    //public class CounterChangedEvent : Event<CounterChangedEvent>
    //{

    //}
}
