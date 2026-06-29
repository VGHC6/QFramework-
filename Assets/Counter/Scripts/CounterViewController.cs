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
            CounterModel.OnCountChanged += UpDataView;
            UpDataView(CounterModel.count);
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                CounterModel.count++;
            });

            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                CounterModel.count--;
            });
        }

        void UpDataView(int newCount)
        {
            Debug.Log("UpDataView");
            transform.Find("Text").GetComponent<TMP_Text>().text = newCount.ToString();
        }
    }

    public class CounterModel
    {
        private static int _count = 0;
        public static Action<int> OnCountChanged;
        public static int count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value != _count)
                {
                    _count = value;
                    OnCountChanged?.Invoke(_count);
                }
            }
        }
    }
}
