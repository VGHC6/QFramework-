using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Counter
{

    public class CounterViewController : MonoBehaviour, IController
    {
        private IConterModel _counterModel;

        public IArchitecture _architecture { get; set; }

        void Start()
        {
            _counterModel = this.GetModel<IConterModel>();

            _counterModel.count._OnValueChanged += UpDataView;

            // CounterChangedEvent.Register(UpDataView);
            //表现逻辑
            UpDataView(_counterModel.count.value);
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //交互逻辑
                this.SendCommand<AddCounterCommand>();

            });

            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                //交互逻辑
                this.SendCommand<SubCounterCommand>();

            });
        }

        private void OnDestroy()
        {
            //CounterChangedEvent.Unregister(UpDataView);
            _counterModel.count._OnValueChanged -= UpDataView;
        }

        void UpDataView(int newValue)
        {
            //Debug.Log("UpDataView");
            transform.Find("Text").GetComponent<TMP_Text>().text = newValue.ToString();
        }

        IArchitecture IBelongArchitecture._GetArchitecture()
        {
            return CounterApp.Interface;
        }
    }


    public interface IConterModel : IMode, IUtility
    {
        BindProerty<int> count { get; }
    }


    public class CounterModel : AbstactMode, IConterModel
    {
        protected override void OnInit()
        {
            var storage =this.GetUtility<IStorage>();

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
