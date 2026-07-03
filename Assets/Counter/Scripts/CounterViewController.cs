using FrameWork;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Counter
{

    public class CounterViewController : MonoBehaviour
    {
        private IConterModel _counterModel;
        void Start()
        {
            _counterModel = CounterApp.Get<IConterModel>();

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


    public interface IConterModel
    {
        BindProerty<int> count { get; }
    }


    public class CounterModel : IConterModel
    {
        public CounterModel()
        {
            var storage = CounterApp.Get<IStorage>();

            count.value = storage.LoadInt("COUNTER_COUNT", 0);
            count._OnValueChanged += count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            };
        }
        public BindProerty<int> count { get; } = new BindProerty<int>
        {
            value = 0
        };
    }




    //public class CounterChangedEvent : Event<CounterChangedEvent>
    //{

    //}
}
